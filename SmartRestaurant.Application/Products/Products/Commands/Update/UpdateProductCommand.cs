using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Commun.Prices;
using Microsoft.EntityFrameworkCore;

namespace SmartRestaurant.Application.Products.Products.Commands.Update
{


    public interface IUpdateProductCommand
    {
        void Execute(UpdateProductModel model);
    }

    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly ILoggerService<UpdateProductCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateProductCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateProductCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateProductModel model)
        {
            try
            {
                var validator = new UpdateProductCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var product = db.Products
                    .Include(x=>x.Pricing)
                    .FirstOrDefault(f => f.Id == guid);
                if (product == null) throw new NotFoundException();


                model.ToEntity(ref product);


                if (!db.ProductFamilies.Any(x => x.Id == product.ProductFamilyId))
                    throw new NotFoundException(nameof(ProductFamily) +
                        product.ProductFamilyId);

                product.PictureId =
           PictureHelper.UpdateEntityPicture(db, model.PictureUrl);

                var pricing = product.Pricing;
                PricingModel.GetPricing(ref pricing, model.Pricing);


                db.Products.Update(product);
                db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
