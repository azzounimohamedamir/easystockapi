using FluentValidation;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Common.Validators
{
    public class DishIngredientCreateDtoValidator : AbstractValidator<DishIngredientCreateDto>
    {
        public DishIngredientCreateDtoValidator()
        {
            RuleFor(x => x.InitialAmount)
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

            RuleFor(x => x.MeasurementUnits)
               .IsInEnum();

            RuleFor(x => x.IngredientId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
