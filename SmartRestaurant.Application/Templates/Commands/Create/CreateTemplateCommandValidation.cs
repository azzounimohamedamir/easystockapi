using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;
using System;

namespace SmartRestaurant.Application.Templates.Commands.Create
{
    public class CreateTemplateCommandValidation : AbstractValidator<ICreateTemplateModel>
    {
        public CreateTemplateCommandValidation()
        {
            RuleFor(x => x.Name).MaximumLength(50)
                .NotEmpty()
                .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage,
                BaseResource.Name));
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(String.Format(SharedValidationResource.MaxlengthNotValideErrorMessage,
                "5"));

        }
    }
}