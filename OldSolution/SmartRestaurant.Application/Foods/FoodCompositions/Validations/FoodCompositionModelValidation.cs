using FluentValidation;
using SmartRestaurant.Application.FoodCompositions.Commands.Models;
using SmartRestaurant.Resources.Commun.Quantity;
using SmartRestaurant.Resources.Commun.Unit;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.FoodCompositions.Validations
{
    public class FoodCompositionModelValidation : AbstractValidator<IFoodCompositionModel>
    {
        public FoodCompositionModelValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.FoodId)               
               .NotNull()
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Food));

            RuleFor(x => x.FoodId)
               .NotEmpty()               
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Food));

            RuleFor(x => x.Quantity.UniteId)
              .NotNull()
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, UnitResource.Unite));

            RuleFor(x => x.Quantity.Value)
                          .NotEmpty()
                          .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, QuantityResource.Quantity));
        }
    }
}
