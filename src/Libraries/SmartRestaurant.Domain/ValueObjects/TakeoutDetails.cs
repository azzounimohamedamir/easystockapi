using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class TakeoutDetails : ValueObject
    {
        public DateTime? DeliveryTime { get; set; }
        public TakeoutType Type { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                DeliveryTime,
                Type
            };
        }
    }
}
