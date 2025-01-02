using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public ICollection<Stock> Products { get; set; }
    }
}
