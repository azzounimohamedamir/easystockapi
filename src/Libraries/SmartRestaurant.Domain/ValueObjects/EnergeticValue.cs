
using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class EnergeticValue : ValueObject 
    {
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbohydrates { get; set; }
        public float Energy { get; set; }
        public float Amount { get; set; }
        public MeasurementUnits MeasurementUnit { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Fat,
                Protein,
                Carbohydrates,
                Energy,
                Amount,
                MeasurementUnit
            };
        }
    }
}
