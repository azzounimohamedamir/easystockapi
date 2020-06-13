using SmartRestaurant.Application.Commun.Quantities;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models
{
    public class DishIngredientModel : IDishIngredientModel
    {
        public DishIngredientModel()
        {
            FoodCategoryParentsIds = new List<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }

        public string FoodId { get; set; }
        public string FoodCategoryId { get; set; }
        public List<string> FoodCategoryParentsIds { get; set; }
        public string FoodUnitId { get; set; }

        public bool IsPrincipal { get; set; }
        public QuantityModel Quantity { get; set; }
        public bool IsSwitchable { get; set; }

    }
}