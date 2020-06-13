using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetBySpecification;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Specifications;
using System.Linq;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetById
{


    public interface IGetRestaurantTypeByIdQuery
    {
        UpdateRestaurantTypeModel Execute(string Id);
    }
    public class GetRestaurantTypeByIdQuery : IGetRestaurantTypeByIdQuery
    {
        private readonly ILoggerService<IGetRestaurantTypeByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;
        private readonly IGetRestaurantTypeBySpecificationQuery spec;

        public GetRestaurantTypeByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetRestaurantTypeByIdQuery> log, 
            IMailingService mailing,
            IGetRestaurantTypeBySpecificationQuery spec,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
            this.spec = spec;
        }

        public UpdateRestaurantTypeModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.RestaurantTypes.Where(x => x.Id == guid).Select(x => new UpdateRestaurantTypeModel
                {
                    Alias = x.Alias,
                    Description =x.Description,
                    Id =x.Id.ToString(),
                    Name =x.Name
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
