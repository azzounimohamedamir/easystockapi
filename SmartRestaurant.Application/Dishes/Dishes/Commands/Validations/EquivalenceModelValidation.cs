using FluentValidation;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Validations
{
    public class DishEquivalenceModelValidation : AbstractValidator<IDishEquivalenceModel>
    {
        public DishEquivalenceModelValidation()
        {
            RuleFor(x => x.ParentId)
              .NotNull()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, DishEquivalenceResource.ParentId));

            RuleFor(x => x.EquivalenceId)
              .NotNull()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, DishEquivalenceResource.EquivalenceId));

            RuleFor(x => x.Quantity).SetValidator(new QuantityValidation());
        }
    }
}
