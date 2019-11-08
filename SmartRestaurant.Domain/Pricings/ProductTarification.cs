using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Pricings
{
    public class ProductTarification : SmartRestaurantBaseEntity<Guid>
    {
        public Product Product { get; set; }
        public Tarification Tarification { get; set; }

        public Guid ProductId { get; set; }
        public Guid TarificationId { get; set; }
    }
}
