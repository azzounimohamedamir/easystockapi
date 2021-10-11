using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Ingredients.Commands
{
    public class CreateIngredientCommand : CreateCommand
    {
        public string Names { get; set; }
        public IFormFile Picture { get; set; }
        public EnergeticValue EnergeticValue { get; set; }
    }

    public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
    {
        public CreateIngredientCommandValidator()
        {
            RuleFor(m => m.Names)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(product => product.Picture)
                .NotEmpty();
        }
    }
}