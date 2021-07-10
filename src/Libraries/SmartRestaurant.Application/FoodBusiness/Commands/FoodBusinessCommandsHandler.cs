using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class FoodBusinessCommandHandler :
        IRequestHandler<CreateFoodBusinessCommand, ValidationResult>,
        IRequestHandler<UpdateFoodBusinessCommand, ValidationResult>,
        IRequestHandler<DeleteFoodBusinessCommand, ValidationResult>
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

        public async Task<ValidationResult> Handle(CreateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            _context.FoodBusinesses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(DeleteFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var entity = await _context.FoodBusinesses.FindAsync(request.CmdId).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.CmdId);

            _context.FoodBusinesses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.CmdId).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.CmdId);

            var validator = new UpdateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            _context.FoodBusinesses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }


        public async Task<ValidationResult> Handle(AddOrUpdateEmployeeRoleInOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new AddOrUpdateEmployeeRoleInOrganizationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var foodBusinessUser = _context.FoodBusinessUsers.First(b =>
                b.FoodBusinessId == request.FoodBusinessId && b.ApplicationUserId == request.UserId.ToString());

            var user = _userManager.Users.First(u => u.Id == foodBusinessUser.ApplicationUserId);
            if (user == null) throw new NotFoundException(nameof(foodBusinessUser), request.FoodBusinessId);

            if (foodBusinessUser == null)
            {
                var foodBusiness = _context.FoodBusinesses.First(b => b.FoodBusinessId == request.FoodBusinessId);
                if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

                foodBusinessUser = new FoodBusinessUser
                {
                    ApplicationUserId = request.UserId.ToString(),
                    FoodBusinessId = request.FoodBusinessId,
                    FoodBusiness = foodBusiness
                };
                await _userManager.AddToRoleAsync(user, request.Role);
                _context.FoodBusinessUsers.Add(foodBusinessUser);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, request.Role);
                await _userManager.AddToRoleAsync(user, request.Role);
                _context.FoodBusinessUsers.Update(foodBusinessUser);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<ValidationResult> Handle(RemoveStaffFromInOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new RemoveStaffFromInOrganizationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var foodBusiness = _context.FoodBusinessUsers.First(b =>
                b.FoodBusinessId == request.FoodBusinessId && b.ApplicationUserId == request.UserId.ToString());

            _context.FoodBusinessUsers.Remove(foodBusiness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
    }
}