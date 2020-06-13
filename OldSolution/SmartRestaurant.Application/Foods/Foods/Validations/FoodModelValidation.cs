using FluentValidation;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Foods.Validations
{
    public class FoodModelValidation : AbstractValidator<IFoodModel>
    {
        public FoodModelValidation()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                    .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                    .MaximumLength(256)
                    .NotEmpty()
                    .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.FoodCategoryId)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.FoodCategoryId));

            RuleFor(x => x.Description)
                    .MaximumLength(380)
                    .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, BaseResource.Description));

        }

    }
}
