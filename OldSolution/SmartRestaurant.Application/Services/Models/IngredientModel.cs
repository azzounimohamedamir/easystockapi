
namespace SmartRestaurant.Application.Services.Models
{
    public class IngredientModel
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public bool IsPrincipal { get; set; }
        public bool IsSwitchable { get; set; }

        public IngredientQuantityModel Quantity { get; set; }//Unit, value
        public IngredientNutritionModel Nutrition { get; set; }
    }
}