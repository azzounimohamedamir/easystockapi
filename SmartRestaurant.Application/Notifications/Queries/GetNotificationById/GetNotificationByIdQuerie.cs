using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Notifications.Commands.Update;
using System.Linq;

namespace SmartRestaurant.Application.Notifications.Queries.GetNotificationById
{


    public interface IGetNotificationByIdQuerie
    {
        UpdateNotificationModel Execute(string Id);
    }
    public class GetNotificationByIdQuerie : IGetNotificationByIdQuerie
    {
        private readonly ILoggerService<GetNotificationByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetNotificationByIdQuerie(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetNotificationByIdQuerie> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateNotificationModel Execute(string Id)
        {
            var entity = db.Notifications
               .Include(x => x.Users)
             .Select(p => new UpdateNotificationModel()
             {
                 Id = p.Id.ToString(),
                 TableName = p.TableName,
                 Name = p.Name,
                 Alias = p.Alias,
                 Description = p.Description,
                 IsDisabled = p.IsDisabled,
                 Action = p.Action,
                 TemplateId = p.TemplateId,
                 Type = p.Type,
                 UsersId = p.Users.Select(x => x.UserId).ToList()
             }).FirstOrDefault();

            return entity;



        }
    }

}
