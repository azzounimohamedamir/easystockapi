using System;

namespace SmartRestaurant.Application.MailingUsers.Commands.Create
{
    public class CreateMailingUserModel
    {
        public Guid MailingId { get; set; }
        public Guid UserId { get; set; }
    }
}