using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;


namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update
{
    public class UpdateDishFamilyModel : IUpdateDishFamilyModel
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public string ParentId { get; set; }
        public PictureModel Picture { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}