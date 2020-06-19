using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.NotificationUsers.Queries.GetMailingUsersByUserId
{
    public interface IGetNotificationUserByMailingIdQuery
    {
        List<NotificationUserItem> Execute(string UserId);
    }

    public class GetNotificationUserByUserIdQuery : IGetNotificationUserByMailingIdQuery
    {
        private readonly ILoggerService<GetNotificationUserByUserIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetNotificationUserByUserIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetNotificationUserByUserIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<NotificationUserItem> Execute(string UserId)
        {
            var entity = db.NotificationUsers
               // .Where(p => p.SRUserId == UserId)
               .Select(p => new NotificationUserItem
               {
                   NotificationId = p.NotificationId,
                   //   UserId = p.SRUserId.ToGuid()
               });
            return entity.ToList();

        }
    }

}
