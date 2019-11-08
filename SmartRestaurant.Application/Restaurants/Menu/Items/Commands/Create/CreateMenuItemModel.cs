using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Models;
using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Models;
using System;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Create
{
    public class CreateMenuItemModel : ICreateMenuItemModel
    {
        public string MenuId { get; set; }
        public MenuItemModel MenuItemModel { get; set; }        
    }
}