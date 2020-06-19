using SmartRestaurant.Application.Commun.Quantities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.DishAccompaniments.Models
{
    public class DishAccompanyingModel : IDishAccompanyingModel
    {
        public string ParentId { get; set; }
        public string AccompanyingId { get; set; }
        public bool IsDisabled { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
