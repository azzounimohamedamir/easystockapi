using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Currency : SmartRestaurantBaseEntity<Guid>
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Symbol { get; set; }
        public virtual ICollection<CountryCurrency> Countries { get; set; }
    }
}
