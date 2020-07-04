using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        public Guid RestaurantId { get; protected set; }
        public string NameArabic { get; protected set; }
        public string NameFrench { get; protected set; }
        public string NameEnglish { get; protected set; }
        public Address Address { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }
        public string Description { get; protected set; }
        public double AverageRating { get; protected set; }
        public int NumberRatings { get; set; }
        public bool HasCarParking { get; protected set; }
        public bool IsHandicapFreindly { get; protected set; }
        public bool AcceptsCreditCards { get; protected set; }
        public bool AcceptTakeout { get; protected set; }
        public string Tags { get; protected set; }
        public string Website { get; protected set; }
        public RestaurantState RestaurantState { get; protected set; }

        public void UpdateRestaurantInfo(string nameArabic, string nameFrench, string nameEnglish, string description, bool hasCarParking, bool isHandicapFreindly, bool acceptsCreditCards, bool acceptTakeout, string tags, string website, double averageRating, int numberRatings)
        {
            NameArabic = nameArabic;
            NameFrench = nameFrench;
            NameEnglish = nameEnglish;
            Description = description;
            HasCarParking = hasCarParking;
            IsHandicapFreindly = isHandicapFreindly;
            AcceptsCreditCards = acceptsCreditCards;
            AcceptTakeout = acceptTakeout;
            Tags = tags;
            Website = website;
            AverageRating = averageRating;
            NumberRatings = numberRatings;
        }

        public void LocatedAt(string streetAddress, string city, string country)
        {
            Address = Address.Create(streetAddress, city, country);
        }

        public void UpdateRestaurantInfo(Restaurant restaurant)
        {
            NameArabic = restaurant.NameArabic;
            NameFrench = restaurant.NameFrench;
            NameEnglish = restaurant.NameEnglish;
            Description = restaurant.Description;
            HasCarParking = restaurant.HasCarParking;
            IsHandicapFreindly = restaurant.IsHandicapFreindly;
            AcceptsCreditCards = restaurant.AcceptsCreditCards;
            AcceptTakeout = restaurant.AcceptTakeout;
            Tags = restaurant.Tags;
            Website = restaurant.Website;
            AverageRating = restaurant.AverageRating;
            NumberRatings = restaurant.NumberRatings;
            LocatedAt(restaurant.Address?.StreetAddress, restaurant.Address?.City, restaurant.Address?.Country);
            if (restaurant.PhoneNumber != null)
                ChangePhoneNumber(restaurant.PhoneNumber.CountryCode, restaurant.PhoneNumber.Number);
            ChangeState(restaurant.RestaurantState);
            CreateMapMarker(restaurant.Address?.GeoPosition?.Latitude, restaurant.Address?.GeoPosition?.Longitude);
        }

        public void CreateMapMarker(string latitude, string longitude)
        {
            Address.CreateMapMarker(latitude, longitude);
        }

        public void ChangePhoneNumber(int CountryCode, int Number)
        {
            PhoneNumber = PhoneNumber.Create(CountryCode, Number);
        }

        public void ChangeState(RestaurantState restaurantState)
        {
            RestaurantState = restaurantState;
        }

        public void Rate(int rating)
        {
            AverageRating = (double)((NumberRatings * AverageRating) + rating) / (NumberRatings + 1);
            NumberRatings += 1;
        }
    }
}