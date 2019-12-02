using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll
{


    public interface IGetAllRestaurantsQuery
    {
        List<RestaurantItemModel> Execute(string typeId=null,string AllergyId=null);
    }
    public class GetAllRestaurantsQuery : IGetAllRestaurantsQuery
    {
        private readonly ILoggerService<GetAllRestaurantsQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllRestaurantsQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllRestaurantsQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<RestaurantItemModel> Execute(string typeId = null, string AllergyId = null)
        {
            try
            {
                var typeGuid = typeId.ToGuid();
                var AllergyGuid = AllergyId.ToGuid();
                return db.Restaurants
                    .Include(o=>o.Owner)
                    .Include(c=>c.Chain)
                    .Include(t=>t.RestaurantType)
                    .Where(x=>(string.IsNullOrEmpty(typeId) || x.RestaurantTypeId== typeGuid)
                           && (string.IsNullOrEmpty(AllergyId) || x.OwnerId == AllergyGuid))
                    .Select(x =>
                    new RestaurantItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        ChainName = x.Chain!=null ? x.Chain.Name:null,
                        Name=x.Name,
                        CreatedDate = x.CreatedDate,
                        Description = x.Description,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
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
