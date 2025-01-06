using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } // Ex: Vetements, Cosmetiques, Alimentation
        public List<CategoryAttribute> CategorieAttributs { get; set; } = new List<CategoryAttribute>();
    }
}
