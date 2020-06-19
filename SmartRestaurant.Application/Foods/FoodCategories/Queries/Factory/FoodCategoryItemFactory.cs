using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Resources.Utils;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory
{
    public static class FoodCategoryItemFactory
    {
        public static FoodCategoryItemModel ToFoodCategoryItemModel(this FoodCategory entity)
        {
            return new FoodCategoryItemModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                ParentName = entity.Parent?.Name,
                PictureUrl = entity.Picture?.ImageUrl,
                Description = entity.Description,
                SlugUrl = entity.SlugUrl,
                IsDisabled = entity.IsDisabled ? UtilsResource.IsDisabledTrueValueText : UtilsResource.IsDisabledFalseValueText,
            };
        }

        public static IEnumerable<FoodCategoryItemModel> ToFoodCategoryItemModels(this IEnumerable<FoodCategory> entities)
        {
            return entities.Select(e => e.ToFoodCategoryItemModel()).ToList();
        }

    }
}
