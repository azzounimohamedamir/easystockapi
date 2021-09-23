using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Ingredients.Commands
{
    public class CreateIngredientCommand : CreateCommand
    {
        public string Name { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Energy { get; set; }
        public Quantity MinQuantity { get; set; }
        public Quantity MaxQuantity { get; set; }

        public Guid FoodBusinessId { get; set; }
    }

    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.FoodBusinessId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}