using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using Xunit;

namespace SmartRestaurant.Domain.Tests
{
    public class FoodBusinessTest
    {
        private readonly FoodBusiness _foodBusiness;

        public FoodBusinessTest()
        {
            _foodBusiness = new FoodBusiness
            {
                Name = "Mon FoodBusiness",
                Description = "Bienvenue chez mon FoodBusiness algerien",
                HasCarParking = true,
                IsHandicapFriendly = true,
                AcceptsCreditCards = true,
                AcceptTakeout = false,
                Tags = "Traditionnelle, Algerien",
                Website = "www.FoodBusiness-exemple.com",
                AverageRating = 4.5,
                NumberRatings = 150
            };
        }

        [Fact]
        public void FoodBusiness_Information_Valid_Test()
        {
            Assert.Equal("Mon FoodBusiness", _foodBusiness.Name);
        }

        [Fact]
        public void FoodBusiness_Address_Valid_Test()
        {
            _foodBusiness.Address = new Address
            {
                StreetAddress = "12 rue exemple",
                City = "Oran",
                Country = "Algeria"
            };

            Assert.Equal("12 rue exemple", _foodBusiness.Address.StreetAddress);
        }

        [Fact]
        public void FoodBusiness_MapMarker_Valid_Test()
        {
            _foodBusiness.Address = new Address
            {
                StreetAddress = "12 rue exemple",
                City = "Oran",
                Country = "Algeria",
                GeoPosition = new GeoPosition
                {
                    Latitude = "+40.75",
                    Longitude = "-074.00"
                }
            };

            Assert.Equal("-074.00", _foodBusiness.Address.GeoPosition.Longitude);
        }

        [Fact]
        public void FoodBusiness_PhoneNumber_Valid_Test()
        {
            _foodBusiness.PhoneNumber = new PhoneNumber
            {
                CountryCode = 213,
                Number = 798924059
            };

            Assert.Equal("798924059", _foodBusiness.PhoneNumber.Number.ToString());
        }

        [Fact]
        public void FoodBusiness_State_Valid_Test()
        {
            _foodBusiness.FoodBusinessState = FoodBusinessState.Active;

            Assert.Equal(FoodBusinessState.Active, _foodBusiness.FoodBusinessState);
        }
    }
}