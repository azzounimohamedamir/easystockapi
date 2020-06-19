using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class Language
    {
        public Guid LanguageId { get; protected set; }
        public string Name { get; protected set; }
        public bool IsRTL { get; protected set; }
        public List<Property> Properties { get; protected set; }
    }
}