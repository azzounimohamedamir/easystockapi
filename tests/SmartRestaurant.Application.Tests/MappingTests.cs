using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;


namespace SmartRestaurant.Application.Tests
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_RestaurantDto_To_Restaurant_Valide_Test()
        {
            RestaurantDto restaurantDto = new RestaurantDto()
            {
                NameFrench = "Mon Restaurant"
            };
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDto);

            Assert.Equal("Mon Restaurant", restaurant.NameFrench);
        }

        [Fact]
        public void Map_RestaurantDto_GeoLocationDto_to_Restaurant_Geolocation_Valide_Test()
        {
            RestaurantDto restaurantDto = new RestaurantDto()
            {
                Address = new AddressDto()
                {
                    City = "Oran",
                    StreetAddress = "12 rue exemple",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto()
                    {
                        Latitude = "+12.5",
                        Longitude = "-24.3"
                    }
                }
            };
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDto);

            Assert.Equal("+12.5,-24.3", restaurant.Address.GeoPosition.GetPosition());
        }

        [Fact]
        public void Map_RestaurantDto_AddressDto_to_Restaurant_Address_Valide_Test()
        {
            RestaurantDto restaurantDto = new RestaurantDto()
            {
                Address = new AddressDto()
                {
                    StreetAddress = "12 rue exemple",
                    City = "Oran",
                    Country = "Algeria"
                }
            };
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDto);

            Assert.Equal("12 rue exemple, Oran, Algeria", restaurant.Address.GetAddresse());
        }

        [Fact]
        public void Map_RestaurantDto_PhoneNumberDto_to_Restaurant_PhoneNumber_Valide_Test()
        {
            RestaurantDto restaurantDto = new RestaurantDto()
            {
                PhoneNumber = new PhoneNumberDto()
                {
                    CountryCode = 213,
                    Number = 798924059
                }
            };
            Restaurant restaurant = _mapper.Map<Restaurant>(restaurantDto);

            Assert.Equal("+213798924059", restaurant.PhoneNumber.GetPhoneNumber());
        }
    }
}