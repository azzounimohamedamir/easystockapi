using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Queries.GetCountryCurrencyByCurrency
{


    public interface IGetCountryCurrencyByCurrencyIdQuerie
    {
        List<CountryCurrencyItem> Execute(string Id);
    }
    public class GetCountryCurrencyByCurrencyIdQuerie : IGetCountryCurrencyByCurrencyIdQuerie
    {
        private readonly ILoggerService<GetCountryCurrencyByCurrencyIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountryCurrencyByCurrencyIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountryCurrencyByCurrencyIdQuerie> logger, IMailingService mailing,
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
               .Where(p => p.CurrencyId.ToString() == Id)
               .Select(p => new CountryCurrencyItem()
               {
                   CurrencyId = p.CurrencyId,
                   CountryId = p.CountryId
               });
            return entity.ToList();

        }
    }

}
