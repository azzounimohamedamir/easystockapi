using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class AttributeValue
    {
        public Guid Id { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string Value { get; set; }

        // Navigation property
        public ProductAttribute ProductAttribute { get; set; }
    }

}
