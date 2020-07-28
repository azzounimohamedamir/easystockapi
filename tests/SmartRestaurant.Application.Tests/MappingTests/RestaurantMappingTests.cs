using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;


namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class RestaurantMappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public RestaurantMappingTests(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_RestaurantDto_To_Restaurant_Valide_Test()
        {
            FoodBusinessDto foodBusinessDto = new FoodBusinessDto()
            {
                NameFrench = "Mon Restaurant"
            };
            Domain.Entities.FoodBusiness restaurant = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("Mon Restaurant", restaurant.NameFrench);
        }

        [Fact]
        public void Map_RestaurantDto_GeoLocationDto_to_Restaurant_Geolocation_Valide_Test()
        {
            FoodBusinessDto foodBusinessDto = new FoodBusinessDto()
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
            Domain.Entities.FoodBusiness restaurant = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("+12.5", restaurant.Address.GeoPosition.Latitude);
        }

        [Fact]
        public void Map_RestaurantDto_AddressDto_to_Restaurant_Address_Valide_Test()
        {
            FoodBusinessDto foodBusinessDto = new FoodBusinessDto()
            {
                Address = new AddressDto()
                {
                    StreetAddress = "12 rue exemple",
                    City = "Oran",
                    Country = "Algeria"
                }
            };
            Domain.Entities.FoodBusiness restaurant = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("12 rue exemple", restaurant.Address.StreetAddress);
        }

        [Fact]
        public void Map_RestaurantDto_PhoneNumberDto_to_Restaurant_PhoneNumber_Valide_Test()
        {
            FoodBusinessDto foodBusinessDto = new FoodBusinessDto()
            {
                PhoneNumber = new PhoneNumberDto()
                {
                    CountryCode = 213,
                    Number = 798924059
                }
            };
            Domain.Entities.FoodBusiness restaurant = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("798924059", restaurant.PhoneNumber.Number.ToString());
        }
    }
}