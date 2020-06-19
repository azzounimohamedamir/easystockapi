using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Templates.Queries.GetTemplateItems
{


    public interface IGetAllTemplateQuerie
    {
        List<TemplateItemModel> Execute();
    }
    public class GetAllTemplateQuerie : IGetAllTemplateQuerie
    {
        private readonly ILoggerService<GetAllTemplateQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllTemplateQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllTemplateQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<TemplateItemModel> Execute()
        {
            var entity = db.Templates
           .Select(p => new TemplateItemModel()
           {
               Name = p.Name,
               Description = p.Description,
               Id = p.Id.ToString(),
               Type = p.Type,
               Alias = p.Alias,
               IsDisabled = p.IsDisabled.DisabledDisplay(),
           });



            return entity.ToList();

        }
    }

}
