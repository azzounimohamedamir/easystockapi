using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Commun.Countries.Factory;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryById;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountryByName;
using SmartRestaurant.Application.Commun.Countries.Queries;
using System.Linq;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Countries.Specifications;

namespace SmartRestaurant.Application.Commun.Countries.Services
{
    public class CountryService : ICountryService
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<CountryService> _log;
        private readonly ICreateCountryFactory _factory;
        private readonly ISelectCountryQuery _selectCountryQuery;

        public CountryService(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CountryService> log,
            ICreateCountryFactory createCountryFactory,
            ISelectCountryQuery selectCountryQuery)
        { 
             _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _factory = createCountryFactory;
            _selectCountryQuery = selectCountryQuery;
        }

        public List<CountryItemModel> List()
        {
            return _db.Countries.ToCountryItemModels();
        }

        public List<CountryItemModel> List(ISpecification<Country> specification)
        {
            return _selectCountryQuery.Execute(specification);
        }        

        public int Count()
        {
            return _db.Countries.Count();
        }

        public int Count(ISpecification<Country> specifications)
        {
            return _db.Countries
                .AsQueryable()
                .ApplySpecification(specifications)
                .Count();
        }

        public int Count(string name)
        {
            return Count(new CountrySpecification(c => c.Name == name));
        }
    }
}
