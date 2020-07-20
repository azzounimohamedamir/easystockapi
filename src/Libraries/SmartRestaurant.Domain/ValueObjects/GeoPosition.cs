using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    [Owned]
    public class GeoPosition : ValueObject
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Latitude,
                Longitude
            };
        }
    }
}
