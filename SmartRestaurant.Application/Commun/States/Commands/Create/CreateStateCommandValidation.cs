using FluentValidation;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.State;
using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.States.Commands.Create
{
    public class CreateStateCommandValidation : AbstractValidator<CreateStateModel>
    {

        public CreateStateCommandValidation()
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
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage
                (String.Format(SharedValidationResource.RequiredErrorMessage
                , StateResource.Country)); 
        }
    }
}
