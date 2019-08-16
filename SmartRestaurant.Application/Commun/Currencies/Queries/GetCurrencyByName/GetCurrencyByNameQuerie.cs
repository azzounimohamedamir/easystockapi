using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyByName
{



    public interface IGetCurrencyByNameQuerie
    {
        GetCurrencyByNameModel Execute(string Name);
    }
    public class GetCurrencyByNameQuerie : IGetCurrencyByNameQuerie
    {
        private readonly ILoggerService<GetCurrencyByNameQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCurrencyByNameQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCurrencyByNameQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public GetCurrencyByNameModel Execute(string Name)
        {
            var entity = db.Currencies
                .Where(p => p.Name == Name)
                .Select(p => new GetCurrencyByNameModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    IsoCode = p.IsoCode,
                    Alias = p.Alias , 
                })
                .FirstOrDefault();
            ;

            return entity;

        }
    }



}
