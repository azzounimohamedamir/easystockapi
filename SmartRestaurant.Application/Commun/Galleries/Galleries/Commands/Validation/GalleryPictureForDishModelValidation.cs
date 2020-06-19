using FluentValidation;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;

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
