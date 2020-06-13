using FluentValidation;

namespace SmartRestaurant.Application.NotificationUsers.Commands.Delete
{
    internal class DeleteNotificationUserCommandValidation : AbstractValidator<DeleteNotificationUserModel>
    {
        public DeleteNotificationUserCommandValidation()
        {
        }
    }
}