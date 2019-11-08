using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Create
{
    public static class ProductFamilyFactory
    {
        public static ProductFamily ToEntity(this CreateProductFamilyModel model)
        {
            return new ProductFamily
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Description = model.Description,
                Name = model.Name,
                IsDisabled = model.IsDisabled,
                RestaurantId = model.RestaurantId.ToGuid()
            };
        }

        public static void ToEntity(this UpdateProductFamilyModel model
            , ref ProductFamily productFamily)
        {

            productFamily.Id = model.Id.ToGuid();
            productFamily.Alias = model.Alias;
            productFamily.Description = model.Description;
            productFamily.Name = model.Name;
            productFamily.IsDisabled = model.IsDisabled;
            productFamily.RestaurantId = model.RestaurantId.ToGuid();
        }
    }
}
