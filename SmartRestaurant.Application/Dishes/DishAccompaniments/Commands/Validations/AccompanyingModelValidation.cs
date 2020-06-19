using FluentValidation;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Dishes.DishAccompaniments.Commands.Validations
{
    public class DishAccompanyingModelValidation : AbstractValidator<IDishAccompanyingModel>//
    {
        public DishAccompanyingModelValidation()
        {
            //RuleFor(x => x.ParentId)
            //  .NotNull()
            //  .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, DishAccompanyingResource.ParentId));

            RuleFor(x => x.AccompanyingId)
             .NotNull()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, DishAccompanyingResource.AccompanyingId));

            RuleFor(x => x.Quantity).SetValidator(new QuantityValidation());

        }
    }
}
