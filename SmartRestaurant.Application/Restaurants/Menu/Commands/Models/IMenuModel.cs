namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Models
{
    public interface IMenuModel
    {
        string Alias { get; set; }
        string ChefId { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string RestaurantId { get; set; }
    }
}