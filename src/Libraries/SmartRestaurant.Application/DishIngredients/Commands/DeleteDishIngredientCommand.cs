using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.DishIngredients.Commands
{
    public class DeleteDishIngredientCommand : DeleteCommand
    {
    }

    public class DeleteDishIngredientCommandValidator : AbstractValidator<DeleteDishIngredientCommand>
    {
        public DeleteDishIngredientCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}