using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using Xunit;

namespace SmartRestaurant.Domain.Tests
{
    public class RestaurantTest
    {
        readonly Restaurant Restaurant;

        public RestaurantTest()
        {
            Restaurant = new Restaurant
            {
                NameArabic = "مطعمي",
                NameFrench = "Mon Restaurant",
                NameEnglish = "My Restaurant",
                Description = "Bienvenue chez mon restaurant algerien",
                HasCarParking = true,
                IsHandicapFreindly = true,
                AcceptsCreditCards = true,
                AcceptTakeout = false,
                Tags = "Traditionnelle, Algerien",
                Website = "www.restaurant-exemple.com",
                AverageRating = 4.5,
                NumberRatings = 150
            };
        }

        [Fact]
        public void Restaurant_Information_Valide_Test()
        {
            Assert.Equal("Mon Restaurant", Restaurant.NameFrench);
        }

        [Fact]
        public void Restaurant_Address_Valide_Test()
        {
            Restaurant.Address = new Entities.Globalisation.Address
            {
                StreetAddress = "12 rue exemple",
                City = "Oran",
                Country = "Algeria"
            };

            Assert.Equal("12 rue exemple", Restaurant.Address.StreetAddress);
        }

        [Fact]
        public void Restaurant_MapMarker_Valide_Test()
        {
            Restaurant.Address = new Entities.Globalisation.Address
            {
                StreetAddress = "12 rue exemple",
                City = "Oran",
                Country = "Algeria"
            };

            Restaurant.Address.GeoPosition = new ValueObjects.GeoPosition
            {
                Latitude = "+40.75",
                Longitude = "-074.00"
            };

            Assert.Equal("-074.00", Restaurant.Address.GeoPosition.Longitude);
        }

        [Fact]
        public void Restaurant_PhoneNumber_Valide_Test()
        {
            Restaurant.PhoneNumber = new ValueObjects.PhoneNumber
            {
                CountryCode = 213,
                Number = 798924059
            };

            Assert.Equal("798924059", Restaurant.PhoneNumber.Number.ToString());
        }

        [Fact]
        public void Restaurant_State_Valide_Test()
        {
            Restaurant.RestaurantState = RestaurantState.Active;

            Assert.Equal(RestaurantState.Active, Restaurant.RestaurantState);
        }
    }
}