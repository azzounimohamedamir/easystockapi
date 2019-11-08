using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Application.Commun.Prices;

namespace SmartRestaurant.Application.Products.Products.Commands.Create
{
    public static class ProductFactory
    {
        public static Product ToEntity(this CreateProductModel model)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Description = model.Description,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                ProductFamilyId = model.ProductFamilyId.ToGuid(),

            };
        }

        public static void ToEntity(this UpdateProductModel model
            , ref Product product)
        {

            product.Id = model.Id.ToGuid();
            product.Alias = model.Alias;
            product.Description = model.Description;
            product.Name = model.Name;
            product.IsDisabled = model.IsDisabled;            
            product.ProductFamilyId = model.ProductFamilyId.ToGuid();

        }

        public static PricingModel ToModel(this Pricing pricing)
        {
            return new PricingModel
            {
                CurrencyId = pricing.Gain.CurrencyId.ToString(),
                Gain = pricing.Gain.Amount,
                IsPercentage = pricing.IsPercentage,
                PurchasePriceHT = pricing.PurchasePriceHT.Amount,
                SalePriceHT= pricing.SalePriceHT.Amount,
                SalePriceTTC= pricing.SalePriceTTC.Amount,
                Tva= pricing.Tva
            };
        }
    }
}
