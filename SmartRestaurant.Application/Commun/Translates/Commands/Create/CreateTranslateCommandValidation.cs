using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Commun.Language;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Create
{
    public class CreateTranslateCommandValidation : AbstractValidator<ICreateTranslateModel>
    {
        public CreateTranslateCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Text)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Text));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.LanguageId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, LanguageResource.Culture));
        }
    }
}