using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class CreateDishCommand : CreateCommand
    {
        public string Name { get; set; }
        public bool IsSupplement { get; set; }
        public Duration AveragePreparationTime { get; set; }
        public float PriceAmount { get; set; }
        public Guid? MenuId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid FoodBusinessId { get; set; }
    }

    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(200);
            RuleFor(m => m.FoodBusinessId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}