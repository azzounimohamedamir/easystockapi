using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class TableViewModel
    {
        public TableViewModel()
        {

        }
        public SelectList Restaurants { get; set; }
        public SelectList Floors { get; set; }
        public SelectList Areas { get; set; }

        public string RestaurantId { get; set; }
        public string FloorId { get; set; }
        public UpdateTableModel UpdateModel { get; set; }
        public CreateTableModel CreateModel { get; set; }
    }
}
