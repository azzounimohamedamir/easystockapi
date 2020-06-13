using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Update
{
    public interface IUpdateMenuItemModel
    {
        string Id { get; set; }
        string MenuId { get; set; }
        MenuItemModel MenuItemModel { get; set; }
    }
}