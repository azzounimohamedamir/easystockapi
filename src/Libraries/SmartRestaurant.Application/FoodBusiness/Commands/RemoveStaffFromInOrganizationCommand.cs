using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class RemoveStaffFromInOrganizationCommand : SmartRestaurantCommand
    {
        public Guid UserId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class RemoveStaffFromInOrganizationCommandValidator : AbstractValidator<RemoveStaffFromInOrganizationCommand>
    {
        public RemoveStaffFromInOrganizationCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().NotEqual(new Guid());
            RuleFor(v => v.FoodBusinessId)
                .NotEmpty().NotEqual(new Guid());
        }
    }
}