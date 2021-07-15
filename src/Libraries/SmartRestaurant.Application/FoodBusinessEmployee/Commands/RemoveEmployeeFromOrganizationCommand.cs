using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class RemoveEmployeeFromOrganizationCommand : SmartRestaurantCommand
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class
        RemoveEmployeeFromInOrganizationCommandValidator : AbstractValidator<RemoveEmployeeFromOrganizationCommand>
    {
        public RemoveEmployeeFromInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}