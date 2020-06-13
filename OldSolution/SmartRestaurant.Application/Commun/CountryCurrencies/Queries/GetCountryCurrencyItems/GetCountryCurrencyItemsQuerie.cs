using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyItems
{
    public interface IGetCountryCurrencyItemsQuerie
    {
        List<CountryCurrencyItem> Execute();
    }
    public class GetCountryCurrencyItemsQuerie : IGetCountryCurrencyItemsQuerie
    {
        private readonly ILoggerService<GetCountryCurrencyItemsQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountryCurrencyItemsQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountryCurrencyItemsQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<CountryCurrencyItem> Execute()
        {
            var entity = db.CountryCurrencies
             .Select(p => new CountryCurrencyItem()
               {
                   CurrencyId = p.CurrencyId,
                   CountryId = p.CountryId
               });
            return entity.ToList();

            
        }
    }

}
