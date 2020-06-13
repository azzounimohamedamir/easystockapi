using FluentValidation;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Resources.Foods.Foods;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Foods.Validations
{
    public class NutritionModelValidation: AbstractValidator<INutritionModel>
    {
        public NutritionModelValidation()
        {
            RuleFor(x => x.Quantity).SetValidator(new QuantityModelValidation());

            RuleFor(x => x.Calorie)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_Calorie));

            RuleFor(x => x.Carbohydrate)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_Carbohydrate));

            RuleFor(x => x.Fibre)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_Fibre));

            RuleFor(x => x.GlycemicIndex)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_GlycemicIndex));

            RuleFor(x => x.Protein)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_Protein));


        }

        public class QuantityModelValidation : AbstractValidator<IQuantityModel>
        {
            public QuantityModelValidation()
            {
                RuleFor(x => x.UnitId)
                    .NotEmpty()
                    .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_UnitId));

                RuleFor(x => x.Value)
                    .NotEmpty()
                    .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, FoodResource.Nutrition_Value));

            }
        }
    }
}
