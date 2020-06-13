using SmartRestaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.ValueObjects
{
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
