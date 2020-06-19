using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Templates.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Templates.Queries.GetTemplateById
{


    public interface IGetTemplateByIdQuerie
    {
        UpdateTemplateModel Execute(string Id);
    }
    public class GetTemplateByIdQuerie : IGetTemplateByIdQuerie
    {
        private readonly ILoggerService<GetTemplateByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTemplateByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTemplateByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateTemplateModel Execute(string Id)
        {
            var entity = db.Templates
            .Where(p => p.Id.ToString() == Id)

           .Select(p => new UpdateTemplateModel()
           {
               Name = p.Name,
               Description = p.Description,
               Type = p.Type,
               Id = p.Id.ToString(),
               IsDisabled = p.IsDisabled,
               Alias = p.Alias,
               Title = p.Title,
               Subject = p.Subject,
               Body = p.Body ,
           }).FirstOrDefault();

            return entity;


        }
    }

}
