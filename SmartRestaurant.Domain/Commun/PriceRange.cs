using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class PriceRange : ValueObject<PriceRange>
    {
        public Guid CurrencyId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }

        public Currency Currency { get; set; }

        //used only for EF core
        private PriceRange() { }

        public PriceRange(Guid currencyId, decimal minAmount, decimal maxAmount)
        {
            CurrencyId = currencyId;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
        }
        protected override bool EqualsCore(PriceRange other)
        {
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CurrencyId;
            yield return MinAmount;
            yield return MaxAmount;
        }
    }
}
