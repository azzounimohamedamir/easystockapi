using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class OwnerViewModel
    {
        public OwnerViewModel()
        {

        }
        public SelectList Parents { get; set; }

        public UpdateOwnerModel UpdateModel { get; set; }
        public CreateOwnerModel CreateModel { get; set; }
    }
}
