using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Queries.Factory
{   
    public static class DishFamilyItemModelFactory
    {
        public static DishFamilyItemModel ToDishFamilyItemModel(this DishFamily entity)
        {
            return new DishFamilyItemModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                RestaurantName=entity.Restaurant?.Name,
                ParentName = entity.Parent?.Name,
                PictureUrl = entity.Picture?.ImageUrl,
                SlugUrl = entity.SlugUrl,
                IsDisabled = entity.IsDisabled ? UtilsResource.IsDisabledTrueValueText : UtilsResource.IsDisabledFalseValueText,
            };
        }

        public static IEnumerable<DishFamilyItemModel> ToDishFamilyItemModels(this IEnumerable<DishFamily> entities)
        {
            return entities.Select(e => e.ToDishFamilyItemModel()).ToList();
        }
    }
    
}
