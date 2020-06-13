using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Foods.Models;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Models
{
    public class FoodCompositionModel : IFoodCompositionModel
    {
        public string Id { get; set; }
        public string FoodId { get; set; }
        public string Alias { get; set; }
        public QuantityModel Quantity { get; set; }
        
    }
}