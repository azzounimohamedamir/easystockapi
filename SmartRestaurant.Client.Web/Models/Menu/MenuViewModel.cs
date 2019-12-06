using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using System;

namespace SmartRestaurant.Client.Web.Models.Menu
{
    public class MenuViewModel
    {
        public string Id { get; set; }
        public SelectList Restaurants { get; set; }
        public SelectList Chefs { get; set; }
        public MenuModel MenuModel { get; set; }

        public string Action { get; set; } = "Add";
        public Guid? RestaurantId { get; set; }
    }
}
