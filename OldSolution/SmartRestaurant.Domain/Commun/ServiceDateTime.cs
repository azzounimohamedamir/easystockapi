using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class ServiceDateTime : ValueObject<ServiceDateTime>
    {
        public DateTime Date { get;  set; }

        public Time StartTime { get;  set; }
        public Time EndTime { get;  set; }

        //for EF migration only
        private ServiceDateTime()
        {

        }
        public ServiceDateTime(DateTime date, Time startTime, Time endDate)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endDate;
        }
        protected override bool EqualsCore(ServiceDateTime other)
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
            yield return Date;
            yield return StartTime.Value;
            yield return EndTime.Value;
        }
    }
}
