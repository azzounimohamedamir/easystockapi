using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public int CountryCode { get; set; }
        public int Number { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                CountryCode,
                Number
            };
        }
    }
}