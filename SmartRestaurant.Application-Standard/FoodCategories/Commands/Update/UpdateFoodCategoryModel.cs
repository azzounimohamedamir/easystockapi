using System;

namespace SmartRestaurant.Application.FoodCategories.Commands.Update
{
    public class UpdateFoodCategoryModel : CreateFoodCategoryModel
    {
        public Guid Id { get; set; }
    }
}