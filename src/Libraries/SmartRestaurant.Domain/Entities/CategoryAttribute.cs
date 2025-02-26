using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class CategoryAttribute
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } // Ex: Pantalon, Chaussures, etc.
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property back to Category

        public List<ProductAttribute> ProductsAttributes { get; set; } = new List<ProductAttribute>();

    }

}
