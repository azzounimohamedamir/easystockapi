using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class FloorViewModel
    {

        public SelectList Restaurants { get; set; }

        public UpdateFloorModel UpdateModel { get; set; }
        public CreateFloorModel CreateModel { get; set; }
    }
}
