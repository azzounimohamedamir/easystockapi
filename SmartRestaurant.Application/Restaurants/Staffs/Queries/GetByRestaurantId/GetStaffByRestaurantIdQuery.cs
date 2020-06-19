using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Staffs.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId
{


    public interface IGetStaffsByRestaurantIdQuery
    {
        IEnumerable<StaffItemModel> Execute(string Id);
    }
    public class GetStaffsByRestaurantIdQuery : IGetStaffsByRestaurantIdQuery
    {
        private readonly ILoggerService<GetStaffsByRestaurantIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;
        private readonly IGetStaffBySpecificationQuery spec;

        public GetStaffsByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetStaffsByRestaurantIdQuery> log,
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


        public IEnumerable<StaffItemModel> Execute(string Id)
        {
            try
            {
                var id = Id.ToGuid();
                return spec.Execute(
                    new StaffSpecification(x => string.IsNullOrEmpty(Id)
                    || x.RestaurantId == id)
                    .AddInclude(i => i.Restaurant));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
