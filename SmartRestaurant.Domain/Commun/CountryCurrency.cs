using System;

namespace SmartRestaurant.Domain.Commun
{
    public class CountryCurrency : SmartRestaurantEntity
    {
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
