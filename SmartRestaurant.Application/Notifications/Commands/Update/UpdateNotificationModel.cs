using SmartRestaurant.Application.Notifications.Commands.Create;

namespace SmartRestaurant.Application.Notifications.Commands.Update
{
    public class UpdateNotificationModel : CreateNotificationModel, IUpdateNotificationModel
    {
        public string Id { get; set; }

    }
}