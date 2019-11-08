using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.FoodCategories.Commands.Create
{
    public static class FoodCategoryExtention
    {
        public static FoodCategory ToEntity(this CreateFoodCategoryModel model)
        {
            return new FoodCategory
            {
                Alias = model.Alias,
                Description = model.Description,
                Name = model.Name,               
                ParentId = model.ParentId ,
                PictureId = model.PictureId,
                SlugUrl = model.SlugUrl
            };
        }
    }
}
