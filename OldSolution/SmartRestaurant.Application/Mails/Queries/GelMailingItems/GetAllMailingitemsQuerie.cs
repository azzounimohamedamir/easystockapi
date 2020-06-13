using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Mails.Queries.GelMailingItems
{


    public interface IGetAllMailingItemsQuerie
    {
        List<MailingItemModel> Execute();
    }
    public class GetAllMailingitemsQuerie : IGetAllMailingItemsQuerie
    {
        private readonly ILoggerService<GetAllMailingitemsQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllMailingitemsQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllMailingitemsQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<MailingItemModel> Execute()
        {
            var entity = db.Mailings
                .Select(p => new MailingItemModel()

                {
                    Id = p.Id.ToString(),
                    TableName = p.TableName,
                    Name = p.Name,
                    Description = p.Description,
                    Alias = p.Alias ,
                    Action = p.Action,
                    templateId = p.TemplateId,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),
                    Type = p.Type,
                    UserList = db.SRUsers
                    .Where(t => p.Users.Select(g => g.UserId).Contains(t.Id)).ToList(),
                    
                    

                }).ToList();

            foreach (var item in entity)
            {
                if (item.UserList.Count != 0)
                {
                    item.UserNames = item.UserList.Select(x => x.UserName).Aggregate((a, b) => b + "-" + a);
                }

            }
            return entity;

        }
    }

}
