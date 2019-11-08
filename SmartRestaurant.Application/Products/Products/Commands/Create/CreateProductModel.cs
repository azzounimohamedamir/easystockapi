using SmartRestaurant.Application.Commun.Prices;

namespace SmartRestaurant.Application.Products.Products.Commands.Create
{
    public class CreateProductModel : ICreateProductModel
    {
        public string ProductFamilyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public string PictureUrl { get; set; }
        public bool IsDisabled { get; set; }
        public PricingModel Pricing { get; set; } = new PricingModel();
    }
}