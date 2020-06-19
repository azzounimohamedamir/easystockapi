using SmartRestaurant.Application.Foods.Models;

namespace SmartRestaurant.Application.Foods.Queries
{
    public class FoodItemModel
    {
        public string Id { get; set; }
        public string FoodCategoryName { get; set; }
        public string PictureUrl { get; set; }
        public NutritionModel NutritionModel { get; set; }
        public bool IsNatural { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SlugUrl { get; set; }
        public string IsDisabled { get; set; }        
        public string Unit { get; set; }
    }
}