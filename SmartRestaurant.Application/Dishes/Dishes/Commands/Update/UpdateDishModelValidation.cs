using FluentValidation;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Commands.Validations;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Validations;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Update
{
    public class UpdateDishModelValidation : AbstractValidator<UpdateDishModel>
    {
        public UpdateDishModelValidation()
        {
            RuleFor(x => x.Id)            
            .NotEmpty()
            .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage,
            BaseResource.Id));
            
            RuleFor(x => x.DishModel).SetValidator(new DishModelValidation());
            RuleFor(x => x.Ingredients).Must(BeANotNullCollection).WithMessage(string.Format(SharedValidationResource.EmptyCollectionMessage,DishResource.Ingredients));
            RuleForEach(x => x.Ingredients).SetValidator(new DishIngredientModelValidation());
            RuleForEach(x => x.Accompaniments).SetValidator(new DishAccompanyingModelValidation());
            RuleForEach(x => x.Equivalences).SetValidator(new DishEquivalenceModelValidation());
            When(x => x.Gallery != null, () =>
            {
                RuleFor(x => x.Gallery).SetValidator(new GalleryModelValidation());
                
            });

        }
        private static bool BeANotNullCollection(List<DishIngredientModel> ingredients)
        {
            if (ingredients == null) return false;
            return true;
        }

    }
}
