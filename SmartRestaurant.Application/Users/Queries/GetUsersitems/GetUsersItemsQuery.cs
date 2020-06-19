using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace SmartRestaurant.Application.Users.Queries.GetUsersitems
{
    public interface IGetUsersItemsQuery
    {
        List<UserItemModel> Execute();
    }



    public class GetUsersItemsQuery : IGetUsersItemsQuery
    {
        private readonly ILoggerService<GetUsersItemsQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetUsersItemsQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetUsersItemsQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<UserItemModel> Execute()
        {
            var entity = db.SRUsers
               .Select(p => new UserItemModel()
               {
                   Id = p.Id.ToString(),
                   LastName = p.LastName,
                   FirstName = p.FirstName,
                   Email = p.Email,
                   UserName = p.UserName,
                   Password = p.PasswordHash,
               });
            return entity.ToList();



        }
    }

}
