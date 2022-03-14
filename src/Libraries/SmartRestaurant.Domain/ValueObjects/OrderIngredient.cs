using SmartRestaurant.Domain.Common;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class OrderIngredient : ValueObject
    {
        public string IngredientId { get; set; }
        public string Names { get; set; }
        public EnergeticValue EnergeticValue { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                IngredientId,
                Names,
                EnergeticValue
            };
        }
    }
}
