using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.MailingUsers.Queries
{
    public class MailingUserItem
    {

        public Guid  MailingId { get; set; }
        public Guid UserId { get; set; }
    }
}
