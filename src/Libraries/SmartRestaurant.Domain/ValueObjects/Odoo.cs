using System.Collections.Generic;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class Odoo : ValueObject
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Db { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Url,
                Username,
                Password,
                Db,

            };
        }
    }
}