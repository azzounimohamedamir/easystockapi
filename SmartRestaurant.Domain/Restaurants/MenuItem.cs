using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Restaurants
{
    public class MenuItem : BaseEntity<Guid>
    {
        public Guid MenuId { get; set; }

        public ICollection<Dish> Dishes { get; set; }

        public ICollection<Product> Products { get; set; }
        /// <summary>
        /// si package le client ne peut pas modifier dans l'offre.        
        /// </summary>
        public bool IsPackage { get; set; }
        //if is package then display gallery of package
        public Guid? GalleryId { get; set; }

        public Menu Menu { get; set; }
        public Gallery Gallery { get; set; }
        //Sum of all dishes prices and all products price then apply discount if exists.
        public Price Discount { get; set; }
    }
}