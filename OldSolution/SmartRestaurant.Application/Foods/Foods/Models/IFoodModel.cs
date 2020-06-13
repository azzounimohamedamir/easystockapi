using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;

namespace SmartRestaurant.Application.Foods.Models
{
    public interface IFoodModel
    {
        string Id { get; set; }
        string Name { get; set; }
        string Alias { get; set; }
        string Description { get; set; }
        string FoodCategoryId { get; set; }        
        bool IsDisabled { get; set; }
        PictureModel Picture { get; set; }
        string UnitId { get; set; }
    }
}