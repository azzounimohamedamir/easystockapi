using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class ChainViewModel
    {
        public SelectList Owners { get; set; }

        public UpdateChainModel UpdateModel { get; set; }
        public CreateChainModel CreateModel { get; set; }
    }
}
