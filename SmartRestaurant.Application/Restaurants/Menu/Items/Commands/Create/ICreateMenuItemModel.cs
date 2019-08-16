using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Create
{
    public interface ICreateMenuItemModel
    {
        MenuItemModel MenuItemModel { get; set; }
    }
}