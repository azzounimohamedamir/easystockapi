using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.ValueObjects;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Entities.Globalisation
{
    [Owned]
    public class Address :  ValueObject
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public GeoPosition GeoPosition { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>{
                City,
                StreetAddress,
                GeoPosition
            };
        }
    }
}
