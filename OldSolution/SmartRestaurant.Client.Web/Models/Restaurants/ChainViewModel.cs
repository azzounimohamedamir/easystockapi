using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class ChainViewModel
    {
        public SelectList Owners { get; set; }
     
        public UpdateChainModel UpdateModel { get; set; }
        public CreateChainModel CreateModel { get; set; }
    }
}
