using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Countries.Factory;
using SmartRestaurant.Application.Commun.Countries.Projections;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Countries.Queries.GetBySpecification
{
    public interface IGetAllCountriesQuerie
    {
        List<CountryItemModel> Execute(ISpecification<Country> specification);
    } 
    public class GetCountriesBySpecifications : IGetAllCountriesQuerie
    {
        private readonly ILoggerService<GetCountriesBySpecifications> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountriesBySpecifications(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountriesBySpecifications> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<CountryItemModel> Execute(ISpecification<Country> specification)
        {

            //return db.Countries
            //        .ApplySpecification(specification)
            //        .Select(CountryItemModelProjection.Projection)   
            //        .ToList();


            return db.Countries
                .ApplySpecification(specification)
                .ToCountryItemModels();
            

        }
    }
}
