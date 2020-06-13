using SmartRestaurant.Application.Commun.Currencies.Commands.Update;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrencyById
{



    public interface IGetCurrencyByIdQuerie
    {
        UpdateCurrencyModel Execute(string Id);
    }
    public class GetCurrencyByIdQuerie : IGetCurrencyByIdQuerie
    {
        private readonly ILoggerService<GetCurrencyByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCurrencyByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCurrencyByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateCurrencyModel Execute(string Id)
        {
            var entity = db.Currencies
                .Where(p => p.Id.ToString() == Id)
                .Select(p => new UpdateCurrencyModel()
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
