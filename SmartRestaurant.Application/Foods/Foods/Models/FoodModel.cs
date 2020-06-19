using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;

namespace SmartRestaurant.Application.Foods.Models
{
    public class FoodModel : IFoodModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string FoodCategoryId { get; set; }
        public bool IsDisabled { get; set; }
        public PictureModel Picture { get; set; }
        public string UnitId { get; set; }
    }
}
