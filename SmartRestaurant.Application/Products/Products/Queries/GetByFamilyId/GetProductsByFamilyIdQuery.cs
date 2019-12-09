using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.Products.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Products.Products.Queries.GetByFamilyId
{


    public interface IGetProductByProductFamilyIdQuery
    {
        List<ProductItemModel> Execute(string Id);
    }
    public class GetProductByProductFamilyIdQuery : IGetProductByProductFamilyIdQuery
    {
        private readonly ILoggerService<GetProductByProductFamilyIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetProductByProductFamilyIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetProductByProductFamilyIdQuery> logger, IMailingService mailing,
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
                return db.Products
                    .Where(p => p.ProductFamilyId == guid)
                    .Include(i=>i.ProductFamily)
                    .Include(i=>i.ProductFamily.Restaurant)
                    .Select(x => new
                    ProductItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Name = x.Name,
                        SlugUrl = x.SlugUrl,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                        ProductFamilyName = x.ProductFamily.Name,
                        RestaurantName = x.ProductFamily.Restaurant.Name
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
