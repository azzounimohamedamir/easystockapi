using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.Products.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Commun.Translators.Extensions;
using SmartRestaurant.Domain.Products;

namespace SmartRestaurant.Application.Products.Products.Queries.GetById
{


    public interface IGetProductByIdQuery
    {
        UpdateProductModel Execute(string Id);
    }
    public class GetProductByIdQuery : IGetProductByIdQuery
    {
        private readonly ILoggerService<GetProductByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetProductByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetProductByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateProductModel Execute(string Id)
        {
            try
            {
                if (Id.IsNullOrEmpty()) return null;

                var prod = db.Products.FirstOrDefault();
               
                var guid = Id.ToGuid();
                var product = db.Products
                    .Include(i => i.Picture)
                    .Include(i => i.ProductFamily)
                    .Include(i => i.Pricing)
                    .Where(p => p.Id == guid)
                    .Select(x => new
                    UpdateProductModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Name = x.Name,
                        SlugUrl = x.SlugUrl,
                        PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                        ProductFamilyName = x.ProductFamily.Name,
                        ResturantId = x.ProductFamily.RestaurantId.ToString(),
                        ProductFamilyId = x.ProductFamilyId.ToString(),
                        Description = x.Description,
                        IsDisabled = x.IsDisabled
                    }).FirstOrDefault();

                var pricing = db.Pricings
                    .FirstOrDefault(x => x.ProductId == guid);
                product.Pricing = pricing.ToModel();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
