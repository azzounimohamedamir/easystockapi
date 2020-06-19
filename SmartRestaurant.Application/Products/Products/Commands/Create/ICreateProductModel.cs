using SmartRestaurant.Application.Commun.Prices;

namespace SmartRestaurant.Application.Products.Products.Commands.Create
{
    public interface ICreateProductModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string PictureUrl { get; set; }
        string ProductFamilyId { get; set; }
        PricingModel Pricing { get; set; }
    }
}