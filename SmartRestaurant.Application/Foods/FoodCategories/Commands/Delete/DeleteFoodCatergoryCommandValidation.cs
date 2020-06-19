using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCategories.Commands.Delete
{
    class DeleteFoodCatergoryCommandValidation: AbstractValidator<DeleteFoodCatergoryModel>
    {
        public DeleteFoodCatergoryCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}
