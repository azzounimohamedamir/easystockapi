using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.NotificationUsers.Queries
{
    public interface IGetNotificationUserByNotificationIdQuery
    {
        List<NotificationUserItem> Execute(string NotificationId);
    }

    public class GetNotificationUserByNotificationIdQuery : IGetNotificationUserByNotificationIdQuery
    {
        private readonly ILoggerService<GetNotificationUserByNotificationIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetNotificationUserByNotificationIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetNotificationUserByNotificationIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<NotificationUserItem> Execute(string NotificationId)
        {
            var entity = db.NotificationUsers
               .Where(p => p.NotificationId == NotificationId.ToGuid())
               .Select(p => new NotificationUserItem
               {
                   NotificationId = p.NotificationId,
                  // UserId = p.SRUserId.ToGuid(),
               });
            return entity.ToList();

        }
    }
}
