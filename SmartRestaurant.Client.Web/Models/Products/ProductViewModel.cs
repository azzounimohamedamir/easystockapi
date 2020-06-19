using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Products
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Picture = new FileViewModel();
        }
        public string RestauratId { get; set; }
        public SelectList Restaurants { get; set; }
        public SelectList ProductFamilies { get; set; }
        public SelectList Currencies { get; set; }
        public FileViewModel Picture { get; set; }

        public UpdateProductModel UpdateModel { get; set; }
        public CreateProductModel CreateModel { get; set; }
    }
}
