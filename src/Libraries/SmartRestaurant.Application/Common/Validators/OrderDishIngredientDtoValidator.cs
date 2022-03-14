using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class OrderDishIngredientDtoValidator : AbstractValidator<OrderDishIngredientDto>
    {
        public OrderDishIngredientDtoValidator()
        {
            RuleFor(x => x.Amount)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .GreaterThanOrEqualTo(x => x.MinimumAmount).WithMessage("'{PropertyName}' must be greater than or equal to Minimum Amount")
                 .LessThanOrEqualTo(x => x.MaximumAmount).WithMessage("'{PropertyName}' must be less than or equal to Maximum Amount");

            RuleFor(x => x.MinimumAmount)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .GreaterThanOrEqualTo(0)
               .LessThan(x => x.MaximumAmount).WithMessage("'{PropertyName}' must be less than Maximum Amount");

            RuleFor(x => x.MinimumAmount)
                .Must(x => false).WithMessage("'{PropertyName}' can not be 0 because it is a primary Ingredient")
                .When(x => x.IsPrimary == true && x.MinimumAmount == 0);

            RuleFor(x => x.AmountIncreasePerStep)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.PriceIncreasePerStep)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Steps)
               .GreaterThanOrEqualTo(0);

            RuleFor(x => x.MeasurementUnits)
               .IsInEnum();

            RuleFor(x => x.OrderIngredient)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull()
              .DependentRules(() => {
                  RuleFor(x => x.OrderIngredient.IngredientId)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .NotEqual(Guid.Empty.ToString())
                    .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

                  RuleFor(x => x.OrderIngredient.Names)
                    .NotEmpty();

                  RuleFor(x => x.OrderIngredient.EnergeticValue)                   
                    .NotEmpty();

                  RuleFor(x => x.OrderIngredient.EnergeticValue.Amount)
                    .GreaterThan(0)
                    .When(x => x.OrderIngredient.EnergeticValue != null);

                  RuleFor(x => x.OrderIngredient.EnergeticValue.MeasurementUnit)
                    .IsInEnum()
                    .When(x => x.OrderIngredient.EnergeticValue != null);

                  RuleFor(x => x.OrderIngredient.EnergeticValue.Fat)
                    .GreaterThanOrEqualTo(0)
                    .When(x => x.OrderIngredient.EnergeticValue != null);

                  RuleFor(x => x.OrderIngredient.EnergeticValue.Protein)
                    .GreaterThanOrEqualTo(0)
                    .When(x => x.OrderIngredient.EnergeticValue != null);

                  RuleFor(x => x.OrderIngredient.EnergeticValue.Carbohydrates)
                    .GreaterThanOrEqualTo(0)
                    .When(x => x.OrderIngredient.EnergeticValue != null);

                  RuleFor(x => x.OrderIngredient.EnergeticValue.Energy)
                    .GreaterThanOrEqualTo(0)
                    .When(x => x.OrderIngredient.EnergeticValue != null);
              });
        }
    }
}
