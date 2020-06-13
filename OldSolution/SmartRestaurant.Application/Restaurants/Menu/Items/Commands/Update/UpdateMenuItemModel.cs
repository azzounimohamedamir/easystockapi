using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Update
{
    public class UpdateMenuItemModel : IUpdateMenuItemModel
    {
        public string Id { get; set; }
        public string MenuId { get; set; }
        public MenuItemModel MenuItemModel { get; set; }        
    }
}