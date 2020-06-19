using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class ChainItemViewModel
    {
        public SelectList Owners { get; set; }
        public string SelectedOwnerId { get; set; }
        public IEnumerable<ChainItemModel> Entities { get; set; }
    }
}
