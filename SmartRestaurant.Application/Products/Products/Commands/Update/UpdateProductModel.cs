using SmartRestaurant.Application.Products.Products.Commands.Create;

namespace SmartRestaurant.Application.Products.Products.Commands.Update
{
    public class UpdateProductModel : CreateProductModel, IUpdateProductModel
    {
        public string Id { get; set; }
        public string SlugUrl { get; set; }
        public string ProductFamilyName { get; set; }
        public string ResturantId { get; set; }

    }
}