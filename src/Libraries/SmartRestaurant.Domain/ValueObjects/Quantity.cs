using System.Collections.Generic;
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class Quantity : ValueObject
    {
        public float Amount { get; set; }
        public MeasurementUnits MeasurementUnits { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Amount,
                MeasurementUnits
            };
        }
    }
}