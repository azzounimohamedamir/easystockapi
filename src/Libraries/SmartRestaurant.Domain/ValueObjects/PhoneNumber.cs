using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.ValueObjects
{
    [Owned]
    public class PhoneNumber : ValueObject
    {
        public int CountryCode { get; protected set; }
        public int Number { get; protected set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                CountryCode,
                Number
            };
        }

        public string GetPhoneNumber()
        {
            return new StringBuilder("+").Append(CountryCode).Append(Number).ToString();
        }

        public static PhoneNumber Create(int countryCode, int number)
        {
            PhoneNumber phoneNumber = new PhoneNumber()
            {
                CountryCode = countryCode,
                Number = number
            };
            return phoneNumber;
        }
    }
}
