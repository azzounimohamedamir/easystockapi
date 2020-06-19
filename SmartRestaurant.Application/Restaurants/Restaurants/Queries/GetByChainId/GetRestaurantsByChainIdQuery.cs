using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetByChainId
{


    public interface IGetRestaurantsByChainIdQuery
    {
        List<RestaurantItemModel> Execute(string Id);
    }
    public class GetRestaurantsByChainIdQuery : IGetRestaurantsByChainIdQuery
    {
        private readonly ILoggerService<GetRestaurantsByChainIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetRestaurantsByChainIdQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetRestaurantsByChainIdQuery> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<RestaurantItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Restaurants
                    .Where(r => r.ChainId == guid)
                    .Select(x =>
                    new RestaurantItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        ChainName = x.Chain != null ? x.Chain.Name : null,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        CreatedDate = x.CreatedDate,
                        Description = x.Description,
                        RestaurantTypeName = x.RestaurantType.Name,
                        OwnerName = x.Owner.FirstName + " " + x.Owner.LastName,
                        AddressModel = x.Address.ToModel()
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
