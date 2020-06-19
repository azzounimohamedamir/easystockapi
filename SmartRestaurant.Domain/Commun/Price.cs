using SmartRestaurant.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    public class Price : ValueObject<Price>
    {
        public Guid CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }

        public static Price operator +(Price left, Price right)
        {
            if (left.CurrencyId != right.CurrencyId)
                throw new NotValidOperation(nameof(Price));
            return new Price(left.CurrencyId, left.Amount + right.Amount);
        }
        public static Price operator -(Price left, Price right)
        {
            if (left.CurrencyId != right.CurrencyId)
                throw new NotValidOperation(nameof(Price));
            return new Price(left.CurrencyId, left.Amount - right.Amount);
        }
        public static Price operator +(Price left, decimal right)
        {
            return new Price(left.CurrencyId, left.Amount + right);
        }
        public static Price operator -(Price left, decimal right)
        {
            return new Price(left.CurrencyId, left.Amount - right);
        }
        public static Price operator /(Price left, decimal right)
        {
            if (right == 0)
                throw new DivideByZeroException("DivideByZeroException:" + nameof(Price));
            return new Price(left.CurrencyId, left.Amount / right);
        }
        public static Price operator *(Price left, decimal right)
        {
            return new Price(left.CurrencyId, left.Amount * right);
        }
        //for EF migration only
        private Price()
        {

        }

        public Price(Guid currencyId, decimal amount)
        {
            CurrencyId = currencyId;
            Amount = amount;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CurrencyId;
            yield return Amount;
        }

        protected override bool EqualsCore(Price other)
        {
            throw new NotImplementedException();
        }
    }
}
