using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.ValueObjects
{
    [Owned]
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

        public override string ToString() {
            return new StringBuilder(CountryCode).Append(Number).ToString();
        }

    }
}
