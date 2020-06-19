using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities.Glabalisation
{
    public class Country : AuditableEntity
    {
        public Guid CountryId { get; protected set; }
        public string Name { get; protected set; }
        public Language FirstLanguage { get; protected set; }
        public Language SecondLanguage { get; protected set; }
        public List<Currency> Currencies { get; protected set; }
        public List<City> Cities { get; protected set; }
        public string FlagPath { get; protected set; }
    }
}
