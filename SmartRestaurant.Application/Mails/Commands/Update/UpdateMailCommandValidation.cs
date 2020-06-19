using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Mailing;
using SmartRestaurant.Resources.SharedValidation;
using System;

namespace SmartRestaurant.Application.Mails.Commands.Update
{
    public class UpdateMailCommandValidation : AbstractValidator<UpdateMailingModel>
    {
        public UpdateMailCommandValidation()
        {

            RuleFor(x => x.TemplateId)
                .NotEmpty()
                .WithMessage(String.Format(SharedValidationResource.RequiredErrorMessage,
                MailingResource.Template));

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