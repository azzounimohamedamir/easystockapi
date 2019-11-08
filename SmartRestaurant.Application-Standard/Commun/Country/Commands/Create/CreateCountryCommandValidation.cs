using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Resources;
using SmartRestaurant.Resources.SharedValidation;
using SmartRestaurant.Resources.Commun.Country;

namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class CreateCountryCommandValidation:AbstractValidator<CreateCountryModel>
    {
        public CreateCountryCommandValidation()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, CountryResource.Name));
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage,"5"));
            RuleFor(x => x.IsoCode)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
        }

    }
}
