using SmartRestaurant.Application.Notifications.Queries;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Notifications.Commands.Factory
{
    public static class NotificationItemModelExtension
    {

        public static NotificationItemModel ToNotificationItemModel(this Notification entity)
        {
            return new NotificationItemModel
            {
                Action = entity.Action,
                TableName = entity.TableName,
                TemplateId = entity.TemplateId,
               


            };

        }

        public static List<NotificationItemModel> ToNotificationItemModels(this IEnumerable<Notification> entities)
        {
            return (from entity in entities
                    select entity.ToNotificationItemModel()).ToList(); 
        }

    }
}
