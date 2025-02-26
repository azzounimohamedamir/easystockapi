using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } // Ex: Vetements, Cosmetiques, Alimentation
        public List<CategoryAttribute> CategorieAttributs { get; set; } = new List<CategoryAttribute>();
    }
}
