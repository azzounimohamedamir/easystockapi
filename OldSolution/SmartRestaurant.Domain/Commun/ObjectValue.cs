using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var other = obj as T;
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, null)) return false;
            return EqualsCore(other);
        }

        protected abstract bool EqualsCore(T other);

        protected abstract IEnumerable<object> GetAtomicValues();

        //public override int GetHashCode()
        //{
        //    return GetHashCodeCore();
        //}
        //protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }
        // Other utility methods
    }
}
