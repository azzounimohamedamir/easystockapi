using SmartRestaurant.Application.Notifications.Commands.Create;

namespace SmartRestaurant.Application.Notifications.Commands.Update
{
    public interface IUpdateNotificationModel : ICreateNotificationModel
    {
        string Id { get; set; }
    }
}