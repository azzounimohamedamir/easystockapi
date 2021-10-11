using System;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.ValueObjects;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Ingredients.Commands
{
    public class UpdateIngredientCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public string Names { get; set; }
        public IFormFile Picture { get; set; }
        public EnergeticValue EnergeticValue { get; set; }
    }

    public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
    {
        public UpdateIngredientCommandValidator()
        {
            RuleFor(m => m.Names)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(ValidatorHelper.IngredientNamesHasArabicLanguage).WithMessage("'{PropertyName}' must have Arabic language")
                .Must(ValidatorHelper.IngredientNamesHasEnglishLanguage).WithMessage("'{PropertyName}' must have English language")
                .Must(ValidatorHelper.IngredientNamesHasFrenchLanguage).WithMessage("'{PropertyName}' must have French language")
                .Must(ValidatorHelper.ValidateJsonSchemaForIngredientNames).WithMessage("'{PropertyName}' invalid json schema");

            RuleFor(m => m.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(product => product.Picture)
                .NotEmpty();

            RuleFor(ingredien => ingredien.EnergeticValue)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .DependentRules(() => {
                   RuleFor(ingredien => ingredien.EnergeticValue.Amount)
                      .GreaterThanOrEqualTo(0);

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