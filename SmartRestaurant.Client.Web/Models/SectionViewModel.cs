using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Section.Commands.Models;
using System;

namespace SmartRestaurant.Client.Web.Models
{
    public class SectionViewModel
    {
        public string Id { get; set; }
        public SelectList Restaurants { get; set; }
        public SelectList Chefs { get; set; }
        public SectionModel SectionModel { get; set; }
        public SelectList Menus { get; set; }

        public string Action { get; set; } = "Add";
        public Guid? RestaurantId { get; set; }

    }
}
