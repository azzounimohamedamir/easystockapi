using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Products.ProductFamilies.Queries.GetById
{


    public interface IGetProductFamilyByIdQuery
    {
        UpdateProductFamilyModel Execute(string Id);
    }
    public class GetProductFamilyByIdQuery : IGetProductFamilyByIdQuery
    {
        private readonly ILoggerService<GetProductFamilyByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetProductFamilyByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetProductFamilyByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateProductFamilyModel Execute(string Id)
        {
            try
            {
                if (Id.IsNullOrEmpty()) return null;

                var guid = Id.ToGuid();
                return db.ProductFamilies
                    .Include(i => i.Restaurant)
                    .Where(p => p.Id == guid)
                    .Select(x => new
                    UpdateProductFamilyModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Name = x.Name,
                        SlugUrl = x.SlugUrl,
                        RestaurantId = x.RestaurantId.ToString(),
                        RestaurantName = x.Restaurant.Name
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
