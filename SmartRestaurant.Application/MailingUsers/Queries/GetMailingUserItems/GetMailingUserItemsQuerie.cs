using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;

namespace SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserItems
{
    public interface IGetMailingUserItemsQuerie
    {
        List<MailingUserItem> Execute();
    }
    public class GetMailingUserItemsQuerie : IGetMailingUserItemsQuerie
    {
        private readonly ILoggerService<GetMailingUserItemsQuerie> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetMailingUserItemsQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetMailingUserItemsQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<MailingUserItem> Execute()
        {
            //var entity = db.MailingUsers
            //   .Select(p => new MailingUserItem
            //   {
            //       MailingId = p.MailingId.ToString(),
            //       UserId = p.UserId
            //   });

            //return entity.ToList();
            return new List<MailingUserItem>();
        }
    }
}
