using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Allergies;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Allergies.Allergies.Queries.Factory
{

    public static class AllergyItemFactory
    {
        public static AllergyItemModel ToAllergyItemModel(this Allergy entity)
        {
            return new AllergyItemModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description,
                SlugUrl = entity.SlugUrl,
                IsDisabled = entity.IsDisabled.DisabledDisplay(),
                Foods = entity.FoodAllergies
                .Select(x => x.Food).ToFoodItemModels()
            };
        }

        public static IEnumerable<AllergyItemModel> ToAllergyItemModels(this IEnumerable<Allergy> entities)
        {
            return entities.Select(e => e.ToAllergyItemModel()).ToList();
        }
    }
}
