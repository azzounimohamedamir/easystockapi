using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class State : SmartRestaurantBaseEntity<string>
    {
        public string CountryId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}