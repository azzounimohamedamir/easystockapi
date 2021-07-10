using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeleteFoodBusinessCommand : SmartRestaurantCommand
    {
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeleteFoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.CmdId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}