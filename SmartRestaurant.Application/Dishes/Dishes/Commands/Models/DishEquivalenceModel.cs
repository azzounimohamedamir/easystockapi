using SmartRestaurant.Application.Commun.Quantities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Models
{
    public class DishEquivalenceModel : IDishEquivalenceModel
    {
        public string ParentId { get; set; }
        public string EquivalenceId { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
