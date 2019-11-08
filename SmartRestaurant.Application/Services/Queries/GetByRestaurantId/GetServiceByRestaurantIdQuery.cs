using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Application.Services.Queries.GetByRestaurantId;
using SmartRestaurant.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Services.Queries
{
    public interface IGetServiceByRestaurantIdQuery
    {
        ServiceModel Execute(string Id);
    }
    public class GetServiceByRestaurantIdQuery : IGetServiceByRestaurantIdQuery
    {
        private readonly ILoggerService<GetServiceByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetServiceByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetServiceByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public ServiceModel Execute(string Id)
        {

            try
            {
                if (Id.IsNullOrEmpty()) return null;

                var guid = Id.ToGuid();
                return db.Services
                    .Include(f=>f.ServiceProducts)
                    .Include(f=>f.ServiceDishes)
                    .Include("ServiceProducts.Product.ProductFamily")
                    .Include("ServiceDishes.Dish.Family.Parent")
                    .Include(f => f.ServiceDishes)
                    .Where(p => p.RestaurantId == guid)
                    .Select(x => new
                    ServiceModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        ServiceName = x.Name,
                        SlugUrl = x.SlugUrl,
                        RestaurantId = Id,
                       Sections= ServiceExtention.GetServiceSections(x.ServiceDishes,x.ServiceProducts),
                       IsClosed = x.Closed
                        
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
