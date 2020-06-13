using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Update
{
    public class UpdateProductFamilyModel : CreateProductFamilyModel, IUpdateProductFamilyModel
    {
        public string Id { get; set; }
        public string SlugUrl { get;  set; }
    }
}