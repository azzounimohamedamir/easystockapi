using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Products
{
    public class Product : BaseEntity<Guid>
    {
        public Guid? PictureId { get; set; }
        public Guid ProductFamilyId { get; set; }
        public Guid? MenuItemId { get; set; }
        public Picture Picture { get; set; }
        public Pricing Pricing { get; set; }

        public MenuItem MenuItem { get; set; }
        public ProductFamily ProductFamily { get; set; }
        public ICollection<ProductTarification> ProductTarifications { get; set; }


    }
}
