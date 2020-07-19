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
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GeoPosition GeoPosition { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>{
                City,
                StreetAddress
            };
        }
    }
}