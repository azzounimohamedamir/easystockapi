using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain
{
    public class Mailing : BaseEntity<Guid>
    {

        public Mailing()
        {
            Users = new List<MailingUser>();

        }
        public string TemplateId { get; set; }
        public Template Template { get; set; }

        //TODO: Controle sur unicité de Action et TableName
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        public EnumNotificationType Type { get; set; }
        public virtual ICollection<MailingUser> Users { get; set; }
    }

    public class MailingUser : SmartRestaurantEntity
    {
        public Guid MailingId { get; set; }
        public string UserId { get; set; }
        public SRUser User { get; set; }
        public Mailing Mailing { get; set; }
    }
}
