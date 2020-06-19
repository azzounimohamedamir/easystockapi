using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Products;
using System;

namespace SmartRestaurant.Domain.Services
{
    public class ServiceProduct : SmartRestaurantBaseEntity<Guid>
    {
        public Guid ServiceId { get; set; }

        public virtual Service Service { get; set; }
        public virtual Product Product { get; set; }

        public Quantity Quantity { get; set; }
    }
}