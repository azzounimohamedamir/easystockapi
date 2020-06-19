using Helpers;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.Products.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Products.Products.Queries.GetByRestaurantId
{

    public interface IGetProductByRestaurantIdQuery
    {
        List<ProductItemModel> Execute(string Id);
    }
    public class GetProductByRestaurantIdQuery : IGetProductByRestaurantIdQuery
    {
        private readonly ILoggerService<GetProductByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetProductByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetProductByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<ProductItemModel> Execute(string Id)
        {

            try
            {
                if (Id.IsNullOrEmpty()) return null;

                var guid = Id.ToGuid();
                return db.Products.Where(p => p.ProductFamily.RestaurantId == guid)
                    .Select(x => new
                    ProductItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        SlugUrl = x.SlugUrl,
                        PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                        ProductFamilyName = x.ProductFamily.Name
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
