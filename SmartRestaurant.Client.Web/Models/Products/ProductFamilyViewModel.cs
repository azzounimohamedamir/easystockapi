using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Products
{
    public class ProductFamilyViewModel
    {
        public ProductFamilyViewModel()
        {
           
        }
        public SelectList Parents { get; set; }
        public string RestaurantId { get; set; }
        public UpdateProductFamilyModel UpdateModel { get; set; }
        public CreateProductFamilyModel CreateModel { get; set; }
    }
}
