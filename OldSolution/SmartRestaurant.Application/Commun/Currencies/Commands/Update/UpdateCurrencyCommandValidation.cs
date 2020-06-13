using FluentValidation;
using SmartRestaurant.Application.Commun.Cities.Commands;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Currencies.Commands
{
    public class UpdateCurrencyCommandValidation : AbstractValidator<IUpdateCurrencyModel>
    {

        public UpdateCurrencyCommandValidation()
        {
            RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty()
            .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage,
            BaseResource.Name));
            RuleFor(x => x.IsoCode)
                .MaximumLength(5)
                .WithMessage(String.Format(SharedValidationResource.MaxlengthNotValideErrorMessage,
                "5"));
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(String.Format(SharedValidationResource.MaxlengthNotValideErrorMessage,
                "5"));

            RuleFor(x => x.Symbol)
                .NotEmpty()
                .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage, "Symbol"));

            RuleFor(x => x.Symbol)
                .MaximumLength(5)
                .WithMessage(String.Format(SharedValidationResource.MaxlengthNotValideErrorMessage,
                "5"));

        }
    }
}
