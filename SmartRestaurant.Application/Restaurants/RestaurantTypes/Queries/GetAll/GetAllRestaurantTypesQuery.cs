using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.Factory;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetAll
{


    public interface IGetAllRestaurantTypesQuery
    {
        List<RestaurantTypeItemModel> Execute();
    }
    public class GetAllRestaurantTypesQuery : IGetAllRestaurantTypesQuery
    {
        private readonly ILoggerService<IGetAllRestaurantTypesQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;
        

        public GetAllRestaurantTypesQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetAllRestaurantTypesQuery> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<RestaurantTypeItemModel> Execute()
        {
            try
            {
                return db.RestaurantTypes.
                    ToRestaurantTypeItemModels();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
