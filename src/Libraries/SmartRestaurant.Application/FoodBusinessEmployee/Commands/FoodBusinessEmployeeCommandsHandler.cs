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

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class FoodBusinessEmployeeCommandsHandler :
        IRequestHandler<AddEmployeeInOrganizationCommand, ValidationResult>,
        IRequestHandler<UpdateEmployeeRoleInOrganizationCommand, ValidationResult>,
        IRequestHandler<RemoveEmployeeFromOrganizationCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodBusinessEmployeeCommandsHandler(IApplicationDbContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ValidationResult> Handle(AddEmployeeInOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new AddEmployeeInOrganizationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var foodBusinessUser = _context.FoodBusinessUsers.First(b =>
                b.FoodBusinessId == request.FoodBusinessId && b.ApplicationUserId == request.UserId.ToString());

            if (foodBusinessUser == null) throw new NotFoundException(nameof(foodBusinessUser), request.FoodBusinessId);

            var user = _userManager.Users.First(u => u.Id == foodBusinessUser.ApplicationUserId);
            if (user == null) throw new NotFoundException(nameof(user), request.UserId);

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
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<ValidationResult> Handle(RemoveEmployeeFromOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new RemoveEmployeeFromInOrganizationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var foodBusiness = _context.FoodBusinessUsers.First(b =>
                b.FoodBusinessId == request.FoodBusinessId && b.ApplicationUserId == request.UserId.ToString());

            _context.FoodBusinessUsers.Remove(foodBusiness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }

        public async Task<ValidationResult> Handle(UpdateEmployeeRoleInOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeRoleInOrganizationCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var foodBusinessUser = _context.FoodBusinessUsers.First(b =>
                b.FoodBusinessId == request.FoodBusinessId && b.ApplicationUserId == request.UserId.ToString());

            if (foodBusinessUser == null) throw new NotFoundException(nameof(foodBusinessUser), request.FoodBusinessId);

            var user = _userManager.Users.First(u => u.Id == foodBusinessUser.ApplicationUserId);
            if (user == null) throw new NotFoundException(nameof(user), request.UserId);

            await _userManager.RemoveFromRoleAsync(user, request.Role);
            await _userManager.AddToRoleAsync(user, request.Role);
            _context.FoodBusinessUsers.Update(foodBusinessUser);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
    }
}