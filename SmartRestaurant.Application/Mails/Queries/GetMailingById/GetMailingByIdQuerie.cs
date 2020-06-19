using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Mails.Commands.Update;
using System.Linq;

namespace SmartRestaurant.Application.Mails.Queries.GetMailingById
{


    public interface IGetMailingByIdQuerie
    {
        UpdateMailingModel Execute(string Id);
    }
    public class GetMailingByIdQuerie : IGetMailingByIdQuerie
    {
        private readonly ILoggerService<GetMailingByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetMailingByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetMailingByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateMailingModel Execute(string Id)
        {
            var entity = db.Mailings
                .Include(x => x.Users)
              .Select(p => new UpdateMailingModel()
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

