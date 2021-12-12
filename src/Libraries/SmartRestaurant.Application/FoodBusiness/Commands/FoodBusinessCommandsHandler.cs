using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class FoodBusinessCommandHandler :
        IRequestHandler<CreateFoodBusinessCommand, Created>,
        IRequestHandler<UpdateFourDigitCodeCommand, NoContent>,
        IRequestHandler<UpdateFoodBusinessCommand, NoContent>,
        IRequestHandler<DeleteFoodBusinessCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodBusinessCommandHandler(IApplicationDbContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Created> Handle(CreateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var user = await _userManager.FindByIdAsync(request.FoodBusinessAdministratorId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.FoodBusinessAdministratorId);

            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            if (roles.Contains(Roles.FoodBusinessAdministrator.ToString()) || roles.Contains(Roles.SuperAdmin.ToString()) || roles.Contains(Roles.SupportAgent.ToString()))
            {
                var entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
                _context.FoodBusinesses.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return default;
            }
            else
            {
                throw new RolesCheckException("The user related to [foodBusinessAdministratorId] must have the role of FoodBusinessAdministrator");
            }


        }

        public async Task<NoContent> Handle(DeleteFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.FoodBusinesses.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            _context.FoodBusinesses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }

        public async Task<NoContent> Handle(UpdateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusinesses = await _context.FoodBusinesses.AsNoTracking()
                .FirstOrDefaultAsync(foodBusinesses => foodBusinesses.FoodBusinessId == Guid.Parse(request.Id), cancellationToken)
                .ConfigureAwait(false);
            if (foodBusinesses == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            _mapper.Map(request, foodBusinesses);
            _context.FoodBusinesses.Update(foodBusinesses);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateFourDigitCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);
            var validator = new UpdateFourDigitCodeCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            entity.FourDigitCode = request.FourDigitCode;
            _context.FoodBusinesses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}