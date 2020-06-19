using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.MailingUsers.Queries.GetMailingUsersByUserId
{
    public interface IGetMailingUserByUserIdQuery
    {
        List<MailingUserItem> Execute(string UserId);
    }

    public class GetMailingUserByUserIdQuery : IGetMailingUserByUserIdQuery
    {
        private readonly ILoggerService<GetMailingUserByUserIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetMailingUserByUserIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetMailingUserByUserIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<MailingUserItem> Execute(string UserId)
        {
            var entity = db.MailingUsers
               //  .Where(p => p.SRUserId == UserId)
               .Select(p => new MailingUserItem
               {
                   MailingId = p.MailingId,
                   //  UserId = p.SRUserId.ToGuid(),
               });
            return entity.ToList();

        }
    }

}
