using FluentValidation;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Resources.Commun.Gallery;
using SmartRestaurant.Resources.SharedValidation;
using System;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation
{
    public class GalleryForDishModelValidation : AbstractValidator<IGalleryForDishModel>
    {
        public GalleryForDishModelValidation()
        {
            RuleFor(g => g.Gallery).SetValidator(new GalleryModelValidation());

            RuleFor(g => g.DishId)
                .NotNull()
                .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage, GalleryResource.DishId));

            RuleForEach(g => g.Pictures).SetValidator(new GalleryPictureForDishModelValidation());
        }
    }
}
