using SmartRestaurant.Domain;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Notifications.Queries
{
    public class NotificationItemModel
    {

        public string Id { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string IsDisabled { get; set; }
        public string TemplateId { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        public EnumNotificationType Type { get; set; }

        public List<SRUser> UserList { get; set; }
        public string UserNames
        {

            get; set;
        }
    }
}
