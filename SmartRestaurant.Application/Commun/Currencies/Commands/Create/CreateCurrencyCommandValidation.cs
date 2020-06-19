using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Create
{
    public class CreateCurrencyCommandValidation : AbstractValidator<ICreateCurrencyModel>
    {

        public CreateCurrencyCommandValidation()
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
