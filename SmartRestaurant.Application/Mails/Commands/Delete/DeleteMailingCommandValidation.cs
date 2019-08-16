using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Mails.Commands.Delete
{
    public class DeleteMailingCommandValidation : AbstractValidator<IDeleteMailingModel>
    {
        public DeleteMailingCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));
        }
    }
}