using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.Products.Queries.GetAll;
using System.Collections.Generic;

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
