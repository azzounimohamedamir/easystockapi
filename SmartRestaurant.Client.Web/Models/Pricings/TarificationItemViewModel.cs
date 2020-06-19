using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Pricings
{
    public class TarificationItemViewModel
    {
        public SelectList Restaurants { get; set; }
        public string SelectedRestaurant { get; set; }
        public IEnumerable<TarificationItemModel> Tarifications { get; set; }
    }
}
