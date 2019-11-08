using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserByMailingId
{
    public interface IGetMailingUserByMailingIdQuery
    {
        List<MailingUserItem> Execute(string MailingId);
    }

    public class GetMailingUserByMailingIdQuery : IGetMailingUserByMailingIdQuery
    {
        private readonly ILoggerService<GetMailingUserByMailingIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetMailingUserByMailingIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetMailingUserByMailingIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<MailingUserItem> Execute(string MailingId)
        {
            var guid = MailingId.ToGuid();
            var entity = db.MailingUsers
               .Where(p => p.MailingId == guid)

               .Select(p => new MailingUserItem
               {
                   //MailingId = p.MailingId.ToString(),
                   //UserId = p.UserId.ToString(),
               });
            return entity.ToList();

        }
    }
}
