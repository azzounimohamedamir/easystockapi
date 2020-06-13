using SmartRestaurant.Application.Commun.Quantities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Foods.Models
{
    public class FoodCompositionModel
    {
        public string Id { get; set; }
        public bool IsDesabled { get; set; }
        public string Alias { get; set; }
        public string FoodId { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
