using SmartRestaurant.Application.Foods.Foods.Models;
using SmartRestaurant.Application.Foods.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public interface IFoodModelCommand
    {
        IFoodModel FoodModel { get; set; }
        INutritionModel Nutrition { get; set; }
        List<FoodCompositionModel> Compositions { get; set; }
    }
}