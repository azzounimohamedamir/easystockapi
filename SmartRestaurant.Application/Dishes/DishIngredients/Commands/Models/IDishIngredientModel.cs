using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models { 
    public interface IDishIngredientModel
    {
        string Alias { get; set; }
        string Description { get; set; }        
        string FoodId { get; set; }
        string Id { get; set; }
        bool IsDisabled { get; set; }
        bool IsPrincipal { get; set; }
        bool IsSwitchable { get; set; }
        string Name { get; set; }
        QuantityModel Quantity { get; set; }
    }
}