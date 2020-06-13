using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Products;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Application.Commun.Prices;

namespace SmartRestaurant.Application.Products.Products.Commands.Create
{


    public interface ICreateProductCommand
    {
        void Execute(CreateProductModel model);
    }

    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly ILoggerService<CreateProductCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateProductCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateProductCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateProductModel model)
        {
            try
            {
                var validator = new CreateProductCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var product = model.ToEntity();
                product.Id = Guid.NewGuid();

                if (!db.ProductFamilies.Any(x => x.Id == product.ProductFamilyId))
                    throw new NotFoundException(nameof(ProductFamily) +
                        product.ProductFamilyId);

                // adding picture
                product.PictureId =
                PictureHelper.AddPictureToEntity(db, model.PictureUrl);

                var pricing = PricingModel.GetPricing(model.Pricing);
                product.Pricing = pricing;

                db.Products.Add(product);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
