using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Country : SmartRestaurantBaseEntity<string>
    {
        public Country()
        {
            Currencies = new List<CountryCurrency> { };
            States = new List<State> { };
        }
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public ICollection<State> States { get; set; }
        public ICollection<CountryCurrency> Currencies { get; set; }
    }
}
