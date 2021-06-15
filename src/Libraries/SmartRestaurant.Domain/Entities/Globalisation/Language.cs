using System;
using System.Collections.Generic;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    public class Language
    {
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public bool IsRTL { get; set; }
        public List<Property> Properties { get; set; }
    }
}