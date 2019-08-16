using System;

namespace SmartRestaurant.Application.FoodCategories.Commands
{
    public class CreateFoodCategoryModel
    {
        public  Guid? ParentId { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Alias { get;  set; }
        public Guid? PictureId { get;  set; }
        public string SlugUrl { get;  set; }
    }
}