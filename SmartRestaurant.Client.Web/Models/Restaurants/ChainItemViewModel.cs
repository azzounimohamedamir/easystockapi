using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class ChainItemViewModel
    {        
        public SelectList Owners { get; set; }  
        public string SelectedOwnerId { get; set; }
        public IEnumerable<ChainItemModel> Entities { get; set; }
    }
}
