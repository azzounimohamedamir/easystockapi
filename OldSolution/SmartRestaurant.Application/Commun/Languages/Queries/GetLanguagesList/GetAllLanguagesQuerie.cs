using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList
{


    public interface IGetAllLanguagesQuerie
    {
        List<LanguageItemModel> Execute();
    }
    public class GetAllLanguagesQuerie : IGetAllLanguagesQuerie
    {
        private readonly ILoggerService<GetAllLanguagesQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllLanguagesQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllLanguagesQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<LanguageItemModel> Execute()
        {
            var entity = db.Languages
            
                .Select(p => new LanguageItemModel()
                {

                    Name = p.Name,
                    IsoCode = p.IsoCode,
                    Alias = p.Alias,
                    Id = p.Id,
                    IsRTL = p.IsRTL,
                    EnglishName = p.EnglishName,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),
                    

                })
               
            ;

            return entity.ToList();
        }
    }

}
