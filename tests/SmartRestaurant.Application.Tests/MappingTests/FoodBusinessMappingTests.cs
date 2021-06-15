using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Tests.Configuration;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class FoodBusinessMappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public FoodBusinessMappingTests(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_FoodBusinessDto_To_FoodBusiness_Valide_Test()
        {
            var foodBusinessDto = new FoodBusinessDto
            {
                Name = "Mon FoodBusiness"
            };
            var foodBusiness = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("Mon FoodBusiness", foodBusiness.Name);
        }

        [Fact]
        public void Map_FoodBusinessDto_GeoLocationDto_to_FoodBusiness_Geolocation_Valide_Test()
        {
            var foodBusinessDto = new FoodBusinessDto
            {
                Address = new AddressDto
                {
                    City = "Oran",
                    StreetAddress = "12 rue exemple",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
                    {
                        Latitude = "+12.5",
                        Longitude = "-24.3"
                    }
                }
            };
            var foodBusiness = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("+12.5", foodBusiness.Address.GeoPosition.Latitude);
        }

        [Fact]
        public void Map_RestaurantDto_AddressDto_to_FoodBusiness_Address_Valide_Test()
        {
            var foodBusinessDto = new FoodBusinessDto
            {
                Address = new AddressDto
                {
                    StreetAddress = "12 rue exemple",
                    City = "Oran",
                    Country = "Algeria"
                }
            };
            var foodBusiness = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("12 rue exemple", foodBusiness.Address.StreetAddress);
        }

        [Fact]
        public void Map_FoodBusinessDto_PhoneNumberDto_to_FoodBusiness_PhoneNumber_Valide_Test()
        {
            var foodBusinessDto = new FoodBusinessDto
            {
                PhoneNumber = new PhoneNumberDto
                {
                    CountryCode = 213,
                    Number = 798924059
                }
            };
            var foodBusiness = _mapper.Map<Domain.Entities.FoodBusiness>(foodBusinessDto);

            Assert.Equal("798924059", foodBusiness.PhoneNumber.Number.ToString());
        }
    }
}