using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class ProductAttribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<AttributeValue> AttributeValues { get; set; }
        public ICollection<CategoryAttribute> CategoryAttributes { get; set; }
    }

}
