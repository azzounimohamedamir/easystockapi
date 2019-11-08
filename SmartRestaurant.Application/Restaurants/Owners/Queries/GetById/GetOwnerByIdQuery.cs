using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetBySpecification;
using SmartRestaurant.Application.Restaurants.Owners.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries.GetById
{
    public interface IGetOwnerByIdQuery
    {
        UpdateOwnerModel Execute(string Id);
    }
    public class GetOwnerByIdQuery : IGetOwnerByIdQuery
    {
        private readonly ILoggerService<IGetOwnerByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly IGetOwnerBySpecificationQuery spec;
        private readonly ISmartRestaurantDatabaseService db;

        public GetOwnerByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetOwnerByIdQuery> log,
            IMailingService mailing,
            IGetOwnerBySpecificationQuery spec,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.spec = spec;
            this.notify = notify;
        }
        public UpdateOwnerModel Execute(string Id)
        {
            try
            {
                var id = Id.ToGuid();
                return db.Owners.Where(o=>o.Id== id)
                    .Select(x => new UpdateOwnerModel
                {
                    Address = x.Address.ToModel(),
                    Alias= x.Alias,
                    DateOfBirth = x.DateOfBirth,
                    IsDisabled = x.IsDisabled,
                    FirstName = x.FirstName,
                    LastName=x.LastName,
                    Id = x.Id.ToString(),
                    UserName = x.UserName
                }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
