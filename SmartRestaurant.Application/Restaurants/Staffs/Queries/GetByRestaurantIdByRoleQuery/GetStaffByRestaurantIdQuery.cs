using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Staffs.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId
{


    public interface IGetByRestaurantIdByRoleQuery
    {
        IEnumerable<StaffItemModel> Execute(string restaurantId, EnumPersoneType type);
    }
    public class GetByRestaurantIdByRoleQuery : IGetByRestaurantIdByRoleQuery
    {
        private readonly ILoggerService<GetByRestaurantIdByRoleQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;
        private readonly IGetStaffBySpecificationQuery spec;

        public GetByRestaurantIdByRoleQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetByRestaurantIdByRoleQuery> log,
            IMailingService mailing,
            IGetStaffBySpecificationQuery spec,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.spec = spec;
            this.notify = notify;
        }


        public IEnumerable<StaffItemModel> Execute(string restaurantId, EnumPersoneType role)
        {
            try
            {
                var id = restaurantId.ToGuid();
                return spec.Execute(
                    new StaffSpecification(x => string.IsNullOrEmpty(restaurantId)
                    ||( x.RestaurantId == id & x.StaffRole==role))
                    .AddInclude(i => i.Restaurant));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
