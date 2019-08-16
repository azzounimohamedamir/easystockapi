using FluentValidation;
using SmartRestaurant.Application.Commun.Prices.Validations;
using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Validations
{
    public class MenuItemModelValidation:AbstractValidator<MenuItemModel>
    {
        public MenuItemModelValidation()
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

            RuleFor(x => x.Discount).SetValidator(new PriceModelValidation());

        }
    }
}
