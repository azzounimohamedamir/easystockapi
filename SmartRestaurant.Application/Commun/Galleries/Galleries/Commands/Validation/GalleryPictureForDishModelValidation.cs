using FluentValidation;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Gallery;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation
{
    public class GalleryPictureForDishModelValidation : AbstractValidator<IGalleryPictureForDishModel>
    {
        public GalleryPictureForDishModelValidation()
        {
            RuleFor(g => g.RestaurantId).NotNull();

            RuleFor(g => g.Picture)
                .SetValidator(new GalleryPictureValidation());
               
        }
    }
}
