using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetBySpecification;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.Staffs.Specifications;
using System.Linq;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.GetById
{


    public interface IGetStaffByIdQuery
    {
        UpdateStaffModel Execute(string Id);
    }
    public class GetStaffByIdQuery : IGetStaffByIdQuery
    {
        private readonly ILoggerService<IGetStaffByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;
        private readonly IGetStaffBySpecificationQuery spec;

        public GetStaffByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetStaffByIdQuery> log,
            IMailingService mailing,
            IGetStaffBySpecificationQuery spec,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
            this.spec = spec;
        }

        public UpdateStaffModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Staffs.Where(s => s.Id == guid)
                    .Select(x => new UpdateStaffModel
                    {
                        Address = x.Address.ToModel(),
                        Alias = x.Alias,
                        DateOfBirth = x.DateOfBirth,
                        IsDisabled = x.IsDisabled,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Id = x.Id.ToString(),
                        RestaurantId = x.RestaurantId.ToString(),
                        UserName = x.UserName,
                        StaffRole = x.StaffRole
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
