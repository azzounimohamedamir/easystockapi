using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Products
{
    public class ProductFamily : BaseEntity<Guid>
    {

        public List<Product> Products { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
