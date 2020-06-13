using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Owner : Persone
    {
        public ICollection<Chain> Chains { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
