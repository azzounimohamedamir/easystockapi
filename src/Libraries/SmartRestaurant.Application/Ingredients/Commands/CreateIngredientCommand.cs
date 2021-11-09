using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
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
                .Must(ValidatorHelper.IngredientNamesHasArabicLanguage).WithMessage("'{PropertyName}' must have Arabic language")
                .Must(ValidatorHelper.IngredientNamesHasEnglishLanguage).WithMessage("'{PropertyName}' must have English language")
                .Must(ValidatorHelper.IngredientNamesHasFrenchLanguage).WithMessage("'{PropertyName}' must have French language")
                .Must(ValidatorHelper.ValidateJsonSchemaForIngredientNames).WithMessage("'{PropertyName}' invalid json schema");

            RuleFor(product => product.Picture)
                .NotEmpty();

            RuleFor(ingredien => ingredien.EnergeticValue)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .DependentRules(() => {
                   RuleFor(ingredien => ingredien.EnergeticValue.Amount)    
                      .GreaterThan(0);

                   RuleFor(ingredien => ingredien.EnergeticValue.MeasurementUnit)
                      .IsInEnum();
                    
                   RuleFor(ingredien => ingredien.EnergeticValue.Fat)
                    .GreaterThanOrEqualTo(0);

                   RuleFor(ingredien => ingredien.EnergeticValue.Protein)
                    .GreaterThanOrEqualTo(0);

                   RuleFor(ingredien => ingredien.EnergeticValue.Carbohydrates)
                    .GreaterThanOrEqualTo(0);

                   RuleFor(ingredien => ingredien.EnergeticValue.Energy)
                    .GreaterThanOrEqualTo(0);
               });
        }
    }
}