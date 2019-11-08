using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Notifications.Commands.Create
{
    public class CreateNotificationModel : ICreateNotificationModel
    {
        public string TemplateId { get; set; }
        public EnumAction Action { get; set; }
        public string TableName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string Alias { get; set; }
        public EnumTemplateType TemplateType { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }
        public EnumNotificationType Type { get; set; }
        public List<string> UsersId { get; set; }
        public string Id { get; set; }

    }
}