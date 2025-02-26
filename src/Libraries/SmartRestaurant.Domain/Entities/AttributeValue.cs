using System;

namespace SmartRestaurant.Domain.Entities
{
    public class AttributeValue
    {
        public Guid Id { get; set; } // Primary key
        public string Valeur { get; set; } // Value of the attribute

        // Foreign key to ProductAttribute
        public Guid ProductAttributeId { get; set; } // Assuming this property exists for the relationship
        public ProductAttribute ProductAttribute { get; set; } // Navigation property back to ProductAttribute
    }

}
