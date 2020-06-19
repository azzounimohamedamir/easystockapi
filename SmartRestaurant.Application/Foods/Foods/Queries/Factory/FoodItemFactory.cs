using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Domain.Foods;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory
{
    public static class FoodItemFactory
    {
        public static FoodItemModel ToFoodItemModel(this Food entity)
        {
            return new FoodItemModel
            {
                Id = entity.Id.ToString(),
                Description = entity.Description,
                Name = entity.Name,
                FoodCategoryName = entity.Category.Name,
                PictureUrl = entity.Picture != null ? entity.Picture.ImageUrl : null,
                SlugUrl = entity.SlugUrl,
                Unit = entity.Unit?.Name,
                //NutritionModel = NutritionModel.GetNutritionModel(entity.Nutrition)
                //TODO:Ef dont accept this
            };
        }

        public static IEnumerable<FoodItemModel> ToFoodItemModels(this IEnumerable<Food> entities)
        {
            return entities.Select(e => e.ToFoodItemModel()).ToList();
        }

    }
}
