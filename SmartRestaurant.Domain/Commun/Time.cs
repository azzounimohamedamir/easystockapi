using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Time : ValueObject<Time>
    {
        public TimeSpan Value { get; private set; }

        private Time()
        {

        }
        public Time(TimeSpan value)
        {
            Value = value;            
        }

        protected override bool EqualsCore(Time other)
        {
            return Value.Equals(other.Value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static Time operator +(Time time1, Time time2)
        {            
            return new Time(time1.Value.Add(time2.Value));
        }

        public static Time operator -(Time time1, Time time2)
        {
            return new Time(time1.Value.Add(-time2.Value));
        }
    }
}
