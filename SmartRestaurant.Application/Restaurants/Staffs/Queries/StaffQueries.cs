using SmartRestaurant.Application.Commun.Select;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using Helpers;
using SmartRestaurant.Application.Restaurants.Staffs.Specifications;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries
{
    public interface IStaffQueries
    {
        IGetStaffByIdQuery GetById { get; }
        IGetStaffsByRestaurantIdQuery GetByRestaurantId { get; }
        IGetStaffBySpecificationQuery Filter { get; }
        IGetAllStaffsQuery List { get; }
        IEnumerable<SelectItemModel> SelectList();
        IEnumerable<SelectItemModel> SelectList(ISpecification<Staff> specification);
    }

    public class StaffQueries : IStaffQueries
    {
        private readonly ILoggerService<StaffQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public StaffQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<StaffQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetStaffByIdQuery id,
            IGetAllStaffsQuery all,
            IGetStaffsByRestaurantIdQuery byrest,
            IGetStaffBySpecificationQuery getStaffBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Filter = getStaffBySpecificationQuery ?? throw new ArgumentNullException(nameof(getStaffBySpecificationQuery));
            List = all ?? throw new ArgumentNullException(nameof(getStaffBySpecificationQuery));
            GetById = id ?? throw new ArgumentNullException(nameof(getStaffBySpecificationQuery));
            GetByRestaurantId = byrest ?? throw new ArgumentNullException(nameof(byrest));
        }


        public IGetStaffBySpecificationQuery Filter { get; private set; }

        public IGetStaffByIdQuery GetById { get; private set; }

        public IGetAllStaffsQuery List { get; private set; }

        public IGetStaffsByRestaurantIdQuery GetByRestaurantId { get; private set; }

        public IEnumerable<SelectItemModel> SelectList()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<SelectItemModel> SelectList(ISpecification<Staff> specification)
        {
            throw new NotImplementedException();
        }
    }
}