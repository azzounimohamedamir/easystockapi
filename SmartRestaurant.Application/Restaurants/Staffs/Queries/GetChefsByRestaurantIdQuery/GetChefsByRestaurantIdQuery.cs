using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.GetChefsByRestaurantIdQuery
{


    public interface IGetChefsByRestaurantIdQuery
    {
        IEnumerable<StaffItemModel> Execute(string restaurantId);
    }

    public class GetChefsByRestaurantIdQuery : IGetChefsByRestaurantIdQuery
    {
        private readonly ILoggerService<GetChefsByRestaurantIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly IGetByRestaurantIdByRoleQuery getByRestaurantIdByRoleQuery;
        private readonly ISmartRestaurantDatabaseService db;
        private readonly IGetStaffBySpecificationQuery spec;

        public GetChefsByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetChefsByRestaurantIdQuery> log,
            IMailingService mailing,
            IGetStaffBySpecificationQuery spec,
            INotifyService notify,
            IGetByRestaurantIdByRoleQuery getByRestaurantIdByRoleQuery)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.spec = spec;
            this.notify = notify;
            this.getByRestaurantIdByRoleQuery = getByRestaurantIdByRoleQuery ?? throw new ArgumentNullException(nameof(getByRestaurantIdByRoleQuery));
        }


        public IEnumerable<StaffItemModel> Execute(string restaurantId)
        {
            try
            {
                return getByRestaurantIdByRoleQuery.Execute(restaurantId, EnumPersoneType.Chef);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
