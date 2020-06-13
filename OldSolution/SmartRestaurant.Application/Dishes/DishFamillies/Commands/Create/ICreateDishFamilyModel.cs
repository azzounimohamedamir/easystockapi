namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create
{
    public interface ICreateDishFamilyModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string ParentId { get; set; }
        string PictureUrl { get; set; }
        string RestaurantId { get; set; }
    }
}