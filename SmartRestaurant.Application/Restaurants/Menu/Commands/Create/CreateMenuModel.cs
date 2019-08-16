using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Create
{
    public class CreateMenuModel
    {
        public MenuModel MenuModel { get; set; }
        public List<MenuItemModel> MenuItems { get; set; }
    }
}