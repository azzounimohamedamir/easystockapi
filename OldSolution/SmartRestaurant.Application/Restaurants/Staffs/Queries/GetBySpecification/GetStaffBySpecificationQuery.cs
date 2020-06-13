using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Projections;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.Factory;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification
{
    public interface IGetStaffBySpecificationQuery
    {
        List<StaffItemModel> Execute(ISpecification<Staff> specification);
    }

    public class GetStaffBySpecificationQuery : IGetStaffBySpecificationQuery
    {
        private readonly ILoggerService<GetStaffBySpecificationQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetStaffBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetStaffBySpecificationQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<StaffItemModel> Execute(ISpecification<Staff> specification)
        {
            //return db.Staffs
            //     .ApplySpecification(specification)                 
            //     .Select(StaffItemModelProjection.Projection).ToList();

            return db.Staffs              
                .ApplySpecification(specification)              
                .ToStaffItemModels();

        }
    }
}
