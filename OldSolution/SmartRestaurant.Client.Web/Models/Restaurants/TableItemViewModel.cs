using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{

    public class TableItemViewModel
    {
        public TableFilterViewModel TableFilterViewModel { get; set; }
        public IEnumerable<TableItemModel> Tables { get; set; }
    }

    public class TableFilterViewModel
    {
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }
        public SelectList Areas { get; set; }
        public string SelectedRestaurantId { get; set; }
        public string SelectedFloorId { get; set; }
        public string SelectedAreaId { get; set; }
    }
}
