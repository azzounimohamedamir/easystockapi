using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GeoPosition GeoPosition { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                City,
                StreetAddress,
                Country
            };
        }
    }
}