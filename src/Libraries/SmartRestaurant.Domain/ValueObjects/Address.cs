using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    [Owned]
    public class Address : ValueObject
    {
        public string StreetAddress { get; protected set; }
        public string City { get; protected set; }
        public string Country { get; set; }
        public GeoPosition GeoPosition { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>{
                City,
                StreetAddress
            };
        }

        public string GetAddresse()
        {
            return new StringBuilder(StreetAddress).Append(", ").Append(City).Append(", ").Append(Country).ToString();
        }

        public static Address Create(string streetAddress, string city, string country)
        {
            Address address = new Address()
            {
                StreetAddress = streetAddress,
                City = city,
                Country = country
            };
            return address;
        }

        public void CreateMapMarker(string latitude, string longitude)
        {
            GeoPosition = GeoPosition.Create(latitude, longitude);
        }
    }
}