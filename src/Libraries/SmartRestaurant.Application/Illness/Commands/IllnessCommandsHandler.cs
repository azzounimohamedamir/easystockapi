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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class IllnessCommandsHandler :
        IRequestHandler<CreateIllnessCommand, Created>,
        IRequestHandler<UpdateIllnessCommand, NoContent>,
        IRequestHandler<DeleteIllnessCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IllnessCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateIllnessCommand request, CancellationToken cancellationToken)
        {
            if (request.Ingredients == null)
                request.Ingredients = new List<IngredientIllnessDto>();

            var validator = new CreateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var illness = _mapper.Map<Domain.Entities.Illness>(request);
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateIllnessCommand request, CancellationToken cancellationToken)
        {
            if (request.Ingredients == null)
                request.Ingredients = new List<IngredientIllnessDto>();
            var validator = new UpdateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var illness = await _context.Illnesses
              .Include(x => x.IngredientIllnesses)
              .ThenInclude(x => x.Ingredient)
              .Where(u => u.IllnessId == Guid.Parse(request.Id))
              .FirstOrDefaultAsync()
              .ConfigureAwait(false);
            var ingredientIllness = await _context.IngredientIllnesses.Where(u => u.IllnessId == Guid.Parse(request.Id)).ToListAsync().ConfigureAwait(false);
            foreach (IngredientIllness ingredientIllness1 in ingredientIllness)
            {
                _context.IngredientIllnesses.Remove(ingredientIllness1);
            }
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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
