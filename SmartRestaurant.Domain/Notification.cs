using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain
{
    public class Notification : BaseEntity<Guid>
    {
        public Notification()
        {
            Users = new List<NotificationUser>();
        }
        public string TemplateId { get; set; }
        public Template Template { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        public EnumNotificationType Type { get; set; }
        public virtual ICollection<NotificationUser> Users { get; set; }
    }

    public class NotificationUser : SmartRestaurantEntity
    {
        public Guid NotificationId { get; set; }
        public string UserId { get; set; }
        public Notification Notification { get; set; }
        public SRUser User { get; set; }

    }
}
