using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class PriceType : BaseEntity<Guid>
    {
        public ICollection<RestaurantPriceType> RestaurantPriceTypes { get; set; }
    }
}
