using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Domain.Enumerations;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Notifications.Queries.GetNotificationById
{
    public class GetNotificationByIdModel : CreateNotificationModel
    {
        public string Id { get; set; }
      

    }
}