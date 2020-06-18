using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    [Owned]
    public class Address :  ValueObject
    {
        public string StreetAddress { get; protected set; }
        public string City { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>{
                City,
                StreetAddress
            };
        }

        public string GetAddresse()
        {
            return new StringBuilder(StreetAddress).Append(", ").Append(City).ToString();
        }

        public static Address Create(string streetAddress, string city)
        {
            Address address = new Address()
            {
                StreetAddress = streetAddress,
                City = city
            };
            return address;
        }
    }
}
