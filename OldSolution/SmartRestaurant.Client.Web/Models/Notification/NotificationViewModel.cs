using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Notification
{
    public class NotificationViewModel
    {
        public CreateNotificationModel CreateModel { get; set; }
        public UpdateNotificationModel UpdateModel { get; set; }
        public SelectList Templates { get; set; }
        public SelectList ActionTypes { get; set; }
        public SelectList NotificationTypes { get; set; }
        public List<UserItemModel> UsersItemModel { get; set; }
    }
}
