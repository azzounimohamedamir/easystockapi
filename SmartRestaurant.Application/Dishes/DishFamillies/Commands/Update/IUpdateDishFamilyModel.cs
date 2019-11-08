using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update
{
    public interface IUpdateDishFamilyModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string ParentId { get; set; }
        PictureModel Picture { get; set; }
        string RestaurantId { get; set; }
    }
}