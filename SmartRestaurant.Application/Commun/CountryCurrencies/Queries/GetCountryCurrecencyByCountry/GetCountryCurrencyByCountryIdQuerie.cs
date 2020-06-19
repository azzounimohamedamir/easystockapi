using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrecencyByCountry
{


    public interface IGetCountryCurrencyByCountryIdQuerie
    {
        List<CountryCurrencyItem> Execute(string Id);
    }
    public class GetCountryCurrencyByCountryIdQuerie : IGetCountryCurrencyByCountryIdQuerie
    {
        private readonly ILoggerService<GetCountryCurrencyByCountryIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountryCurrencyByCountryIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountryCurrencyByCountryIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<CountryCurrencyItem> Execute(string Id)
        {
            var entity = db.CountryCurrencies
               .Where(p => p.CountryId == Id)
               .Select(p => new CountryCurrencyItem()
               {
                   CurrencyId = p.CurrencyId,
                   CountryId = p.CountryId
               });
            return entity.ToList();


        }
    }

}
