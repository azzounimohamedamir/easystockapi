using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Notifications.Commands.Update
{
    public class UpdateNotificationModel : CreateNotificationModel,IUpdateNotificationModel
    {
        public string Id { get; set; }
       
    }
}