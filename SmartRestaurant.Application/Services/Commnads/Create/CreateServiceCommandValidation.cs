using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Commnads.Create
{
    public class CreateServiceCommandValidation : AbstractValidator<ICreateServiceModel>
    {
        public CreateServiceCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.RestaurantId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Restaurant));
        }
    }
}
