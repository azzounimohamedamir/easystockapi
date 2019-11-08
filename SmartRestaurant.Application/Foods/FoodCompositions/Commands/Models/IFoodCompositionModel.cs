using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Models
{
    public interface IFoodCompositionModel
    {
        string Alias { get; set; }
        string FoodId { get; set; }
        string Id { get; set; }
        QuantityModel Quantity { get; set; }
    }
}