using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class CategoryAttribute
    {
        public Guid CategoryId { get; set; }
        public Guid ProductAttributeId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }

}
