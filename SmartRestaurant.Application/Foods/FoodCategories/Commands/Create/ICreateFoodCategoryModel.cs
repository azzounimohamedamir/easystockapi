using System;

namespace SmartRestaurant.Application.FoodCategories.Commands
{
    public interface ICreateFoodCategoryModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string ParentId { get; set; }

        string PictureId { get; set; }   
        string PictureUrl { get; set; }
    }
}