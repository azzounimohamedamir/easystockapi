using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    public class Country : AuditableEntity
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public Language FirstLanguage { get; set; }
        public Language SecondLanguage { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<City> Cities { get; set; }
        public string FlagPath { get; set; }
    }
}