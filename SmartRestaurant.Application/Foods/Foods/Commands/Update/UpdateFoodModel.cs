using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Foods.Models;
using SmartRestaurant.Application.Foods.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Foods.Commands.Update
{
    public class UpdateFoodModel : IFoodModelCommand
    {
        public IFoodModel FoodModel { get; set; }
        public INutritionModel Nutrition { get; set; }
        public List<FoodCompositionModel> Compositions { get; set; }

    }
}