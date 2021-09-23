using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class Duration : ValueObject
    {
        public float Value { get; set; }
        public TimeUnits TimeUnits { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Value,
                TimeUnits
            };
        }
    }
}