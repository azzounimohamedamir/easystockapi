using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using Microsoft.EntityFrameworkCore;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById
{


    public interface IGetRestaurantByIdQuery
    {
        UpdateRestaurantModel Execute(string Id);
    }
    public class GetRestaurantByIdQuery : IGetRestaurantByIdQuery
    {
        private readonly ILoggerService<GetRestaurantByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetRestaurantByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetRestaurantByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateRestaurantModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Restaurants
                    .Where(r => r.Id == guid)
                    .Include(o => o.Owner)
                    .Include(c => c.Chain)
                    .Include(t => t.RestaurantType)
                    .Select(x =>
                    new UpdateRestaurantModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        ChainName = x.Chain != null ? x.Chain.Name : null,
                        Name = x.Name,
                        CreatedDate = x.CreatedDate,
                        Description = x.Description,
                        ChainId = x.ChainId != null ? x.ChainId.ToString() : null,
                        OwnerId = x.OwnerId.ToString(),
                        RestaurantTypeId = x.RestaurantTypeId.ToString(),
                        RestaurantTypeName = x.RestaurantType.Name,
                        AllergyName = x.Owner.FirstName + " " + x.Owner.LastName,
                        AddressModel = x.Address.ToModel()
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
