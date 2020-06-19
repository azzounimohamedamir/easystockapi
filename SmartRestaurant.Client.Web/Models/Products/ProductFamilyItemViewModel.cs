using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Products
{
    public class ProductFamilyItemViewModel
    {
        public ProductFamilyItemViewModel()
        {
           
        }
        public SelectList Rerstaurants { get; set; }   
        public string SelectedRestaurantId { get; set; }
         public IEnumerable<ProductFamilyItemModel> Entities { get; set; }
    }
}
