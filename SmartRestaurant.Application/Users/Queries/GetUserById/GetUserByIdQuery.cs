using SmartRestaurant.Application.Interfaces;
using System.Linq;
namespace SmartRestaurant.Application.Users.Queries.GetUserById
{


    public interface IGetUserByIdQuery
    {
        UserItemModel Execute(string Id);
    }
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly ILoggerService<GetUserByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetUserByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetUserByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UserItemModel Execute(string Id)
        {
            var entity = db.SRUsers
               .Where(p => p.Id == Id)
               .Select(p => new UserItemModel()
               {
                   Id = p.Id.ToString(),
                   LastName = p.LastName,
                   FirstName = p.FirstName,
                   Email = p.Email,
                   UserName = p.UserName,
                   Password = p.PasswordHash,

               }).FirstOrDefault();
            return entity;

        }
    }

}
