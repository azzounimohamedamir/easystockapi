using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class AddOrUpdateEmployeeRoleInOrganizationCommand : SmartRestaurantCommand
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string Role { get; set; }
    }

    public class
        AddOrUpdateEmployeeRoleInOrganizationCommandValidator : AbstractValidator<
            AddOrUpdateEmployeeRoleInOrganizationCommand>
    {
        public AddOrUpdateEmployeeRoleInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().NotEqual(new Guid());
            RuleFor(v => v.FoodBusinessId)
                .NotEmpty().NotEqual(new Guid());
        }
    }
}