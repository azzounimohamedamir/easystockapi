
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Allergies;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries.Factory
{
    public static class IllnessItemFactory
    {
        public static IllnessItemModel ToIllnessItemModel(this Illness entity)
        {
            return new IllnessItemModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                SlugUrl = entity.SlugUrl,
                Description = entity.Description,
                IsDisabled = entity.IsDisabled.DisabledDisplay(),
                Foods = entity.FoodIllnesses
                .Select(x => x.Food).ToFoodItemModels()
            };
        }

        public static IEnumerable<IllnessItemModel> ToIllnessItemModels(this IEnumerable<Illness> entities)
        {
            return entities.Select(e => e.ToIllnessItemModel()).ToList();
        }
    }
}
