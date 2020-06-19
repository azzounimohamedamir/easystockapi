using SmartRestaurant.Application.Notifications.Commands.Create;

namespace SmartRestaurant.Application.Notifications.Queries.GetNotificationById
{
    public class GetNotificationByIdModel : CreateNotificationModel
    {
        public string Id { get; set; }


    }
}