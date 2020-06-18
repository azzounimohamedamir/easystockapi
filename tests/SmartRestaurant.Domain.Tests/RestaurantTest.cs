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
            Restaurant = Restaurant.Create("مطعمي", "Mon Restaurant", "My Restaurant", "Bienvenue chez mon restaurant algerien", true, true, true, false, "", "", 4.5, 150);
        }

        [Fact]
        public void Restaurant_Information_Test()
        {
            Assert.Equal("Mon Restaurant", Restaurant.NameFrench);
        }

        [Fact]
        public void Restaurant_Address_Test()
        {
            Restaurant.LocatedAt("12 rue exemple", "Oran");
            Assert.Equal("12 rue exemple, Oran", Restaurant.Address.GetAddresse());
        }

        [Fact]
        public void Restaurant_MapMarker_Test()
        {
            Restaurant.CreateMapMarker("+40.75", "-074.00");
            Assert.Equal("-074.00", Restaurant.GeoPosition.Longitude);
        }

        [Fact]
        public void Restaurant_PhoneNumber_Test()
        {
            Restaurant.ChangePhoneNumber(213, 798924059);
            Assert.Equal("+213798924059", Restaurant.PhoneNumber.GetPhoneNumber());
        }

        [Fact]
        public void Restaurant_State_Test()
        {
            Restaurant.ChangeState(RestaurantState.Active);
            Assert.Equal(RestaurantState.Active, Restaurant.RestaurantState);
        }

        [Fact]
        public void Restaurant_Rating_Test()
        {
            Restaurant.Rate(4);
            Assert.NotEqual(4.5, Restaurant.AverageRating);
        }
    }
}