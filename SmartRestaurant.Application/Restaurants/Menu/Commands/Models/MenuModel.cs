using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Models
{
    public class MenuModel : IMenuModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string MenuId { get; set; }
        public string RestaurantId { get; set; }
        public string ChefId { get; set; }
    }
}
