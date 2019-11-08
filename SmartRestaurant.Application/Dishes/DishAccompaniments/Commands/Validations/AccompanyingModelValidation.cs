using FluentValidation;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
