using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Common.Validators
{
    public class IllnessIngedientValidator : AbstractValidator<IngredientIllnessDto>
    {
        public IllnessIngedientValidator()
        {
            RuleFor(x => x.Quantity)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty()
             .GreaterThan(0)
             .WithMessage("'{PropertyName}' of Ingredient can not be 0");
        }
    }
}
