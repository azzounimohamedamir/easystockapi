using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Delete
{
    public class DeleteFoodCompositionsCommandValidation : AbstractValidator<DeleteFoodCompositionsModel>
    {
        public DeleteFoodCompositionsCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
        }
    }
}
