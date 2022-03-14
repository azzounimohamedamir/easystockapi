using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class DeleteFoodBusinessCommand : DeleteCommand
    {
    }

    public class DeleteFoodBusinessCommandValidator : AbstractValidator<DeleteFoodBusinessCommand>
    {
        public DeleteFoodBusinessCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().NotEqual(Guid.Empty);
        }
    }
}