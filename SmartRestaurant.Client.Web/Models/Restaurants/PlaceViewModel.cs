using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Places.Commands.Create;
using SmartRestaurant.Application.Restaurants.Places.Commands.Update;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{

    public class PlaceViewModel
    {
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }
        public SelectList Areas { get; set; }
        public SelectList Tables { get; set; }

        public string RestaurantId { get; set; }
        public string FloorId { get; set; }
        public string AreaId { get; set; }
        public UpdatePlaceModel UpdateModel { get; set; }
        public CreatePlaceModel CreateModel { get; set; }
    }
}
