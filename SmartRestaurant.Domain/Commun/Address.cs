using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Commun
{
    //Address value object persisted as owned entity in EF Core 2.0
    //<EntityName>Configuration.OwnsOne(o => o.Address);
    [Owned]
    public class Address : ValueObject<Address>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        //Map
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        //used only for EF core
        private Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }

        protected override bool EqualsCore(Address other)
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

        //TODO: Implemente InTheSameCountry
        public bool InTheSameCountry(Address other)
        {
            throw new NotImplementedException();
        }
        //TODO: Implemente InTheSameState
        public bool InTheSameState(Address other)
        {
            throw new NotImplementedException();
        }
        //TODO: Implemente InTheSameCity
        public bool InTheSameCity(Address other)
        {
            throw new NotImplementedException();
        }
        //TODO: Implemente InTheSameStreet
        public bool InTheSameStreet(Address other)
        {
            throw new NotImplementedException();
        }
    }
}
