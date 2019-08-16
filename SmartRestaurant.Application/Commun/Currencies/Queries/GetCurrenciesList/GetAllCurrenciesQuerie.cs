using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Currencies.Queries.GetCurrenciesList
{


    public interface IGetAllCurrenciesQuery
    {
        List<CurrencyItemModel> Execute();
    }
    public class GetAllCurrenciesQuerie : IGetAllCurrenciesQuery
    {
        private readonly ILoggerService<GetAllCurrenciesQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllCurrenciesQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllCurrenciesQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<CurrencyItemModel> Execute()
        {
            var entity = db.Currencies
                .Select(p => new CurrencyItemModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    IsoCode = p.IsoCode,
                    Alias = p.Alias ,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),
                });

            return entity.ToList(); 


        }
    }

}
