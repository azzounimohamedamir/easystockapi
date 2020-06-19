using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Notifications.Queries.GetNotificationItems
{


    public interface IGetNotificationItemsQuery
    {
        List<NotificationItemModel> Execute();
    }
    public class GetNotificationItemsQuerie : IGetNotificationItemsQuery
    {
        private readonly ILoggerService<GetNotificationItemsQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetNotificationItemsQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetNotificationItemsQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<NotificationItemModel> Execute()
        {
            var entity = db.Notifications
                .Include(x => x.Users)
                .Include("Users.User")
                .Select(p => new NotificationItemModel()
                {
                    Id = p.Id.ToString(),
                    TableName = p.TableName,
                    Name = p.Name,
                    Description = p.Description,
                    Alias = p.Alias,
                    Action = p.Action,
                    TemplateId = p.TemplateId,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),
                    //Body = p.Body,
                    //Subject = p.Subject,
                    //Title = p.Title,
                    Type = p.Type,
                    UserList = db.SRUsers
                    .Where(t => p.Users.Select(g => g.UserId).Contains(t.Id)).ToList()





                }).ToList();

            foreach (var item in entity)
            {
                if (item.UserList.Count != 0)
                {
                    item.UserNames = item.UserList.Select(x => x.UserName).Aggregate((a, b) => b + "-" + a);
                }
            }
            return entity;

        }
    }

}
