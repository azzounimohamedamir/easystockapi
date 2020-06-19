using FluentValidation;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Validations
{
    public class DishIngredientModelValidation:AbstractValidator<IDishIngredientModel>
    {
        public DishIngredientModelValidation()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.Description)
               .MaximumLength(380)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "380"));

            RuleFor(x => x.FoodId)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishIngredientResource.FoodId));



            RuleFor(x => x.Quantity).SetValidator(new QuantityValidation());
               
        }
    }
}
