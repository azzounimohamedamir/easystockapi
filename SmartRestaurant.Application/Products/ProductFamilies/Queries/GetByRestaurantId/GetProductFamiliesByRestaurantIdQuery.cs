using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId
{


    public interface IGetProductFamiliesByRestaurantIdQuery
    {
        List<ProductFamilyItemModel> Execute(string Id);
    }
    public class GetProductFamiliesByRestaurantIdQuery : IGetProductFamiliesByRestaurantIdQuery
    {
        private readonly ILoggerService<GetProductFamiliesByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetProductFamiliesByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetProductFamiliesByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<ProductFamilyItemModel> Execute(string Id)
        {
            try
            {
                if (Id.IsNullOrEmpty()) return null;

                var guid = Id.ToGuid();
                return db.ProductFamilies
                    .Where(p => p.RestaurantId == guid)
                    .Include(i => i.Restaurant)
                    .Select(x => new
                    ProductFamilyItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        SlugUrl = x.SlugUrl,
                        RestaurantName = x.Restaurant.Name
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
