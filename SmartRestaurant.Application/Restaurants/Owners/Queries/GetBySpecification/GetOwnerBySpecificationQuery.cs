using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Queries.Factory;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries.GetBySpecification
{
    public interface IGetOwnerBySpecificationQuery
    {
        List<OwnerItemModel> Execute(ISpecification<Owner> specification);

    }

    public class GetOwnerBySpecificationQuery : IGetOwnerBySpecificationQuery
    {
        private readonly ILoggerService<GetOwnerBySpecificationQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetOwnerBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetOwnerBySpecificationQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<OwnerItemModel> Execute(ISpecification<Owner> specification)
        {
            try
            {
                return db.Owners
                              .ApplySpecification(specification)
                              .ToOwnerItemModels()
                              .ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }


    }
}
