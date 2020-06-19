using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Quantity: ValueObject<Quantity>
    {
        public decimal Value { get; private set; }
        public Guid UnitId { get; private set; }

        public virtual Unit Unit { get; set; }

        //for EF migration only
        private Quantity()
        {

        }

        public Quantity(Guid unitId,decimal value)
        {
            UnitId = unitId;
            Value = value;
        }

        protected override bool EqualsCore(Quantity other)
        {
            return UnitId.Equals(other.UnitId) & Value.Equals(other.Value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return UnitId;
        }               

        public static Quantity operator +(Quantity quantity1, Quantity quantity2)
        {
            if (!quantity1.UnitId.Equals(quantity2.UnitId))
            {
                throw new InvalidCastException();
            }
            return new Quantity(quantity1.UnitId, quantity1.Value + quantity2.Value);
        }

        public static Quantity operator -(Quantity quantity1, Quantity quantity2)
        {
            if (!quantity1.UnitId.Equals(quantity2.UnitId))
            {
                throw new InvalidCastException();
            }
            return new Quantity(quantity1.UnitId, quantity1.Value - quantity2.Value);
        }
    }
}
