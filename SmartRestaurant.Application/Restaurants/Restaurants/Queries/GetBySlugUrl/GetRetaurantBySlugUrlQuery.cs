using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl
{


    public interface IGetRetaurantBySlugUrlQuery
    {
        RestaurantItemModel Execute(string slugUrl);
    }
    public class GetRetaurantBySlugUrlQuery : IGetRetaurantBySlugUrlQuery
    {
        private readonly ILoggerService<GetRetaurantBySlugUrlQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetRetaurantBySlugUrlQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetRetaurantBySlugUrlQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public RestaurantItemModel Execute(string slugUrl)
        {
            try
            {                
                return db.Restaurants
                    .Where(r => r.SlugUrl == slugUrl)
                    .Include(o => o.Owner)
                    .Include(c => c.Chain)
                    .Include(t => t.RestaurantType)
                    .Select(x =>
                    new RestaurantItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        ChainName = x.Chain != null ? x.Chain.Name : null,
                        Name = x.Name,
                        SlugUrl=x.SlugUrl,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        CreatedDate = x.CreatedDate,
                        Description = x.Description,
                        RestaurantTypeName = x.RestaurantType.Name,
                        OwnerName = x.Owner.FirstName + " " + x.Owner.LastName,
                        AddressModel = x.Address.ToModel()
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
                
    }

}
