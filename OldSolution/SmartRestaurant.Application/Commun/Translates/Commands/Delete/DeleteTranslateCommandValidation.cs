using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Delete
{
    public class DeleteTranslateCommandValidation : AbstractValidator<DeleteTranslateModel>
    {
        public DeleteTranslateCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));

        }
    }
}