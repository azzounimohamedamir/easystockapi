using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Create
{
    public class CreateMenuItemModel : ICreateMenuItemModel
    {
        public string MenuId { get; set; }
        public MenuItemModel MenuItemModel { get; set; }
    }
}