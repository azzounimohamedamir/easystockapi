using FluentValidation;

namespace SmartRestaurant.Application.NotificationUsers.Commands.Create
{
    public class CreateNotificationUserCommandValidation : AbstractValidator<CreateNotificationUserModel>
    {
        public CreateNotificationUserCommandValidation()
        {
        }
    }
}