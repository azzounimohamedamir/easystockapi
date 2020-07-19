using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class Language
    {
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public bool IsRTL { get; set; }
        public List<Property> Properties { get; set; }
    }
}