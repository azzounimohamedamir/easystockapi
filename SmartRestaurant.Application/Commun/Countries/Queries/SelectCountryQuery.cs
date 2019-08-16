using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Countries.Factory;

namespace SmartRestaurant.Application.Commun.Countries.Queries
{
    public interface ISelectCountryQuery
    {
        List<CountryItemModel> Execute(ISpecification<Country> specifications);
    }

    public class SelectCountryQuery:ISelectCountryQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<SelectCountryQuery> _log;
        
        public SelectCountryQuery(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<SelectCountryQuery> log  
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;
           
        }

        public List<CountryItemModel> Execute(ISpecification<Country> specifications) => _db.Countries
                .AsQueryable()
                .ApplySpecification(specifications)
                .ToCountryItemModels();
    }
}
