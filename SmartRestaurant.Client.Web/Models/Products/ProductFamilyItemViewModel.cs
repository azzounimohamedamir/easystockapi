using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using System.Collections.Generic;

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
