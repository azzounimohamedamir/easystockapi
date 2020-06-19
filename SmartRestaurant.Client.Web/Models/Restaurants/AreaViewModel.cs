using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class AreaViewModel
    {
        public AreaViewModel()
        {

        }
        public string RestaurantId { get; set; }
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }

        public UpdateAreaModel UpdateModel { get; set; }
        public CreateAreaModel CreateModel { get; set; }
    }
}
