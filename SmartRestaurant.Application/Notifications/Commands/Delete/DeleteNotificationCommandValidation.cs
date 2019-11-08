using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Notifications.Commands.Delete
{
    public class DeleteNotificationCommandValidation : AbstractValidator<IDeleteNotificationModel>
    {
        public DeleteNotificationCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));
        }
    }
}