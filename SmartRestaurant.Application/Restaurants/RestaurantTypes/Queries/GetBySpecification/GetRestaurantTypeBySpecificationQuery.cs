using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.Factory;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetBySpecification
{
   
    public interface IGetRestaurantTypeBySpecificationQuery
    {
        List<RestaurantTypeItemModel> Execute(ISpecification<RestaurantType> specification);
    }

    public class GetRestaurantTypeBySpecificationQuery : IGetRestaurantTypeBySpecificationQuery
    {
        private readonly ILoggerService<GetRestaurantTypeBySpecificationQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetRestaurantTypeBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetRestaurantTypeBySpecificationQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<RestaurantTypeItemModel> Execute(ISpecification<RestaurantType> specification)
        {
            return db.RestaurantTypes
                 .ApplySpecification(specification)
                 .ToRestaurantTypeItemModels()
                 .ToList();
        }
    }
}
