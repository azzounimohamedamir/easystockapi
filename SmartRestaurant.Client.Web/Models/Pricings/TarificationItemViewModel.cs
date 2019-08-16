using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
using SmartRestaurant.Domain.Pricings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Pricings
{
    public class TarificationItemViewModel
    {
        public SelectList Restaurants { get; set; }
        public string SelectedRestaurant { get; set; }
        public IEnumerable<TarificationItemModel> Tarifications { get; set; }
    }
}
