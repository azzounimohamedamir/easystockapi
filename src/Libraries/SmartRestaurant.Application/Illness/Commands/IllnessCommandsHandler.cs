using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class IllnessCommandsHandler :
        IRequestHandler<CreateIllnessCommand, Created>,
        IRequestHandler<CreateIllnessUserCommand, Created>,
        IRequestHandler<UpdateIllnessCommand, NoContent>,
        IRequestHandler<DeleteIllnessCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public IllnessCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateIllnessCommand request, CancellationToken cancellationToken)
        {
            if (request.Ingredients == null)
                request.Ingredients = new List<IngredientIllnessDto>();
            var illnessName = await _context.Illnesses
           .FirstOrDefaultAsync(u => u.Name.ToUpper() == request.Name.ToUpper(), cancellationToken)
           .ConfigureAwait(false); ;
            if (illnessName != null)
            {
                throw new ConflictException("Illness '" + request.Name + "' already exists");
            }
            var validator = new CreateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var illness = _mapper.Map<Domain.Entities.Illness>(request);
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }



        public async Task<Created> Handle(CreateIllnessUserCommand request, CancellationToken cancellationToken)
        {

            if(request.IllnessIds.Count == 0)
            {
                await RemoveOldIlnessUserChoice(cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            }
            else
            {
                await RemoveOldIlnessUserChoice(cancellationToken);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                foreach (var ilnessid in request.IllnessIds)
                {
                    var ilnessUser = new IlnessUser
                    {
                        ApplicationUserId = _userService.GetUserId(),
                        IllnessId = Guid.Parse(ilnessid)
                    };

                    await _context.ilnessUsers.AddAsync(ilnessUser).ConfigureAwait(false);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            return default;
        }








        private async Task RemoveOldIlnessUserChoice(CancellationToken cancellationToken)
        {
            var user = _userService.GetUserId();

            var list = await _context.ilnessUsers.Where(a=>a.ApplicationUserId == user).ToListAsync();
            foreach (var item in list)
            {
                _context.ilnessUsers.Remove(item);
            }
        }








        public async Task<NoContent> Handle(UpdateIllnessCommand request, CancellationToken cancellationToken)
        {
            if (request.Ingredients == null)
                request.Ingredients = new List<IngredientIllnessDto>(); 
            var illnessName = await _context.Illnesses
              .FirstOrDefaultAsync(u => u.Name.ToUpper() == request.Name.ToUpper() && u.IllnessId.ToString() != request.Id,cancellationToken)
              .ConfigureAwait(false); ;
            if(illnessName != null)
            {
                throw new ConflictException("Illness '"+ request.Name + "' already exists");
            }
            var validator = new UpdateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var illness = await _context.Illnesses
              .Include(x => x.IngredientIllnesses)
              .ThenInclude(x => x.Ingredient)
              .Where(u => u.IllnessId == Guid.Parse(request.Id))
              .FirstOrDefaultAsync()
              .ConfigureAwait(false);
            if (illness == null)
            {
                throw new NotFoundException(nameof(Illness), request.Id);
            }

            _mapper.Map(request, illness);
            _context.Illnesses.Update(illness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteIllnessCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var illness = await _context.Illnesses.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (illness == null) throw new NotFoundException(nameof(Illness), request.Id);

            _context.Illnesses.Remove(illness);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        
    }
}
