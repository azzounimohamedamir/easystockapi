using System;

namespace SmartRestaurant.Application.NotificationUsers.Commands.Create
{
    public class CreateNotificationUserModel
    {

        public Guid MailingId { get; set; }
        public Guid UserId { get; set; }
    }
}