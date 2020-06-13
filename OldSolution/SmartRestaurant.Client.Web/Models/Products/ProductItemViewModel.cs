using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Application.Products.Products.Queries.GetAll;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Products
{
    public class ProductItemViewModel
    {
        public ProductItemViewModel()
        {
             
        }

        public SelectList Restaurants { get; set; }
        public SelectList ProductFamilies { get; set; }

        public string SelectedRestaurantId { get; set; }
        public string SelectedFamilyId { get; set; }
        public IEnumerable<ProductItemModel> Entities { get; set; }
    }
}
