using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.DishIngredients.Commands
{
    public class CreateDishIngredientCommand : CreateCommand
    {
        public bool IsPrimary { get; set; }
        public QuantityDto Quantity { get; set; }
        public QuantityDto AmountPerStep { get; set; }
        public float PricePerStep { get; set; }
        public Guid DishId { get; set; }
        public Guid IngredientId { get; set; }
    }

    public class CreateDishIngredientCommandValidator : AbstractValidator<CreateDishIngredientCommand>
    {
        public CreateDishIngredientCommandValidator()
        {
            RuleFor(m => m.DishId).NotEmpty().Must(id => id != Guid.Empty);
            RuleFor(m => m.IngredientId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}