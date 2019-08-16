using FluentValidation;
using SmartRestaurant.Application.FoodCompositions.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Quantity;
using SmartRestaurant.Resources.Commun.Unit;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Update
{
    public class UpdateFoodCompositionsCommandValidation : AbstractValidator<IFoodCompositionModel>
    {
        public UpdateFoodCompositionsCommandValidation()
        {

            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.FoodId)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Food));

            RuleFor(x => x.Quantity.UniteId)
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, UnitResource.Unite));
            RuleFor(x => x.Quantity.Value)
                          .NotEmpty()
                          .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, QuantityResource.Quantity));
        }
    }
}
