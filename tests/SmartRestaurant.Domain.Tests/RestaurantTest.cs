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
            Restaurant = Restaurant.Create(nameArabic: "مطعمي", 
                nameFrench: "Mon Restaurant", 
                nameEnglish: "My Restaurant", 
                description: "Bienvenue chez mon restaurant algerien", 
                hasCarParking: true, 
                isHandicapFreindly: true, 
                acceptsCreditCards: true, 
                acceptTakeout: false, 
                tags: "Traditionnelle", 
                website: "www.restaurant-exemple.com", 
                averageRating: 4.5, 
                numberRatings: 150);
        }

        [Fact]
        public void Restaurant_Information_Valide_Test()
        {
            Assert.Equal("Mon Restaurant", Restaurant.NameFrench);
        }

        [Fact]
        public void Restaurant_Address_Valide_Test()
        {
            Restaurant.LocatedAt("12 rue exemple", "Oran", "Algeria");
            Assert.Equal("12 rue exemple, Oran, Algeria", Restaurant.Address.GetAddresse());
        }

        [Fact]
        public void Restaurant_MapMarker_Valide_Test()
        {
            Restaurant.LocatedAt("12 rue exemple", "Oran", "Algeria");
            Restaurant.CreateMapMarker("+40.75", "-074.00");
            Assert.Equal("-074.00", Restaurant.Address.GeoPosition.Longitude);
        }

        [Fact]
        public void Restaurant_PhoneNumber_Valide_Test()
        {
            Restaurant.ChangePhoneNumber(213, 798924059);
            Assert.Equal("+213798924059", Restaurant.PhoneNumber.GetPhoneNumber());
        }

        [Fact]
        public void Restaurant_State_Valide_Test()
        {
            Restaurant.ChangeState(RestaurantState.Active);
            Assert.Equal(RestaurantState.Active, Restaurant.RestaurantState);
        }

        [Fact]
        public void Restaurant_Rating_NotValide_Test()
        {
            Restaurant.Rate(4);
            Assert.NotEqual(4.5, Restaurant.AverageRating);
        }
    }
}