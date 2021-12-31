using System;
using AutoMapper;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class CommissionMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public CommissionMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }
      

        [Fact]
        public void Map_SetFoodBusinessCommissionCommand_To_FoodBusiness_Valide_Test()
        {
            var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
            {
                Value = 25,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusinessCustomer,
            };

            var foodBusiness = new Domain.Entities.FoodBusiness
            {
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new Address
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPosition
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                HasCarParking = true,
                IsHandicapFriendly = true,
                Name = "Taj mahal",
                OffersTakeout = true,
                PhoneNumber = new PhoneNumber { CountryCode = 213, Number = 670217536 },
                Tags = "pizza;sandwish",
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                DefaultCurrency = Currencies.USD,
                CommissionConfigs = null
            };



            _mapper.Map(setFoodBusinessCommissionCommand, foodBusiness);
            Assert.Equal(foodBusiness.AcceptsCreditCards, foodBusiness.AcceptsCreditCards);
            Assert.Equal(foodBusiness.AcceptTakeout, foodBusiness.AcceptTakeout);
            Assert.Equal(foodBusiness.Address.City, foodBusiness.Address.City);
            Assert.Equal(foodBusiness.Address.StreetAddress, foodBusiness.Address.StreetAddress);
            Assert.Equal(foodBusiness.Address.Country, foodBusiness.Address.Country);
            Assert.Equal(foodBusiness.Address.GeoPosition.Latitude, foodBusiness.Address.GeoPosition.Latitude);
            Assert.Equal(foodBusiness.Address.GeoPosition.Longitude, foodBusiness.Address.GeoPosition.Longitude);
            Assert.Equal(foodBusiness.Description, foodBusiness.Description);
            Assert.Equal(foodBusiness.HasCarParking, foodBusiness.HasCarParking);
            Assert.Equal(foodBusiness.IsHandicapFriendly, foodBusiness.IsHandicapFriendly);
            Assert.Equal(foodBusiness.Name, foodBusiness.Name);
            Assert.Equal(foodBusiness.OffersTakeout, foodBusiness.OffersTakeout);
            Assert.Equal(foodBusiness.PhoneNumber.CountryCode, foodBusiness.PhoneNumber.CountryCode);
            Assert.Equal(foodBusiness.PhoneNumber.Number, foodBusiness.PhoneNumber.Number);
            Assert.Equal(foodBusiness.Tags, foodBusiness.Tags);
            Assert.Equal(foodBusiness.Email, foodBusiness.Email);
            Assert.Equal(foodBusiness.Website, foodBusiness.Website);
            Assert.Equal(foodBusiness.FoodBusinessAdministratorId, foodBusiness.FoodBusinessAdministratorId);
            Assert.Equal(foodBusiness.DefaultCurrency, foodBusiness.DefaultCurrency);
            Assert.False(foodBusiness.IsActivityFrozen);
            Assert.Equal(setFoodBusinessCommissionCommand.Value, foodBusiness.CommissionConfigs.Value);
            Assert.Equal(setFoodBusinessCommissionCommand.Type, foodBusiness.CommissionConfigs.Type);
            Assert.Equal(setFoodBusinessCommissionCommand.WhoPay, foodBusiness.CommissionConfigs.WhoPay);





        }

    }
}