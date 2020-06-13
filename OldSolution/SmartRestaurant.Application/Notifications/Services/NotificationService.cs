using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Delete;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Notifications.Queries;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationById;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Notifications.Services
{
   public interface INotificationService
    {
        ICreateNotificationCommand Create { get; }
        IUpdateNotificationCommand Update { get; }
        IDeleteNotificationCommand Delete { get; }
        INotificationQueries Queries { get;  }
    }
    public class NotificationService
    {
    }
}
