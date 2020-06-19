using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Owner : Persone
    {
        public ICollection<Chain> Chains { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
