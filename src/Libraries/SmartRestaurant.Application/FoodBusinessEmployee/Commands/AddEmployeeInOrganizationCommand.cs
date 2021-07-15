using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class AddEmployeeInOrganizationCommand : SmartRestaurantCommand
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string Role { get; set; }
    }

    public class AddEmployeeInOrganizationCommandValidator : AbstractValidator<AddEmployeeInOrganizationCommand>
    {
        public AddEmployeeInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(v => v.FoodBusinessId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}