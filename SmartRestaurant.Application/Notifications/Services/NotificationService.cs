using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Delete;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Notifications.Queries;

namespace SmartRestaurant.Application.Notifications.Services
{
    public interface INotificationService
    {
        ICreateNotificationCommand Create { get; }
        IUpdateNotificationCommand Update { get; }
        IDeleteNotificationCommand Delete { get; }
        INotificationQueries Queries { get; }
    }
    public class NotificationService
    {
    }
}
