using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities
{
    public class ProductAttribute
    {
        // Navigation property
        public Guid Id { get; set; }
        public string Nom { get; set; } // Ex: Taille, Couleur, etc.
        public Guid CategoryAttributeId { get; set; }
        public CategoryAttribute CategoryAttribute { get; set; } // Navigation property back to CategoryAttribute

        public List<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
    }

}
