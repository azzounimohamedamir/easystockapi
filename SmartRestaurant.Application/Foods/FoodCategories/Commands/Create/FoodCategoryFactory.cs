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
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                Description = model.Description,
                Name = model.Name,   
                IsDisabled=model.IsDisabled,
                ParentId = model.ParentId.ToNullableGuid() ,
                PictureId = model.PictureId.ToNullableGuid(),
            };
        }
    }
}
