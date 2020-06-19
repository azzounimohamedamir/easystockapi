using FluentValidation;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;

namespace SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Validation
{
    public class GalleryPictureValidation : AbstractValidator<IGalleryPictureModel>
    {
        public GalleryPictureValidation()
        {
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.Description)
               .MaximumLength(380)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "380"));

            RuleFor(x => x.ImageUrl).Must(BeAValidUrl);
        }

        private static bool BeAValidUrl(string arg)
        {
            Uri result;
            return Uri.TryCreate(arg, UriKind.Absolute, out result);
        }
    }
}