using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace SmartRestaurant.Application.NotificationUsers.Queries.GetNotificationUserItem
{

    public interface IGetNotificationUsersItemQuery
    {
        List<NotificationUserItem> Execute();
    }

    public class GetNotificationUsersItemQuery : IGetNotificationUsersItemQuery
    {
        private readonly ILoggerService<GetNotificationUsersItemQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetNotificationUsersItemQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetNotificationUsersItemQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<NotificationUserItem> Execute()
        {
            var entity = db.NotificationUsers

               .Select(p => new NotificationUserItem
               {
                   NotificationId = p.NotificationId,
                   // UserId = p.SRUserId.ToGuid()
               });
            return entity.ToList();

        }
    }





}
