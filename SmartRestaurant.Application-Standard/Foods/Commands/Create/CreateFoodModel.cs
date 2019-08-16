using System;

namespace SmartRestaurant.Application.Foods.Commands.Create
{
    public class CreateFoodModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string FoodCategoryId { get; set; }
        public string PictureUrl { get; set; }
        public CreateNutritionModel Nutrition { get; set; }
    }
}