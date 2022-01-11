using System;
using AutoMapper;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
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

        Domain.Entities.FoodBusiness foodBusiness = new Domain.Entities.FoodBusiness
        {
            FoodBusinessId = Guid.NewGuid(),
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

        [Fact]
        public void Map_SetFoodBusinessCommissionCommand_To_FoodBusiness_Valide_Test()
        {
            var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
            {
                Value = 25,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusinessCustomer,
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



        [Fact]
        public void Map_FoodBusiness_To_MonthlyCommission_Valide_Test()
        {
            var newFoodBusiness = foodBusiness;
            newFoodBusiness.CommissionConfigs = new CommissionConfigs
            {
                Value = 20,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusiness
            };

            var now = DateTime.Now.AddMonths(-1);
            var monthlyCommission = _mapper.Map<MonthlyCommission>(foodBusiness);
            Assert.Equal(foodBusiness.FoodBusinessId, monthlyCommission.FoodBusinessId);
            Assert.Equal(CommissionStatus.Unpaid, monthlyCommission.Status);
            Assert.Equal(0, monthlyCommission.TotalToPay);
            Assert.Equal(0, monthlyCommission.numberOfOrdersOrPersons);
            Assert.Equal(new DateTime(now.Year, now.Month, 1, 0, 0, 0), monthlyCommission.Month);
            Assert.Equal(foodBusiness.CommissionConfigs.Value, monthlyCommission.CommissionConfigs.Value);
            Assert.Equal(foodBusiness.CommissionConfigs.Type, monthlyCommission.CommissionConfigs.Type);
            Assert.Equal(foodBusiness.CommissionConfigs.WhoPay, monthlyCommission.CommissionConfigs.WhoPay);
        }

        [Fact]
        public void Map_FoodBusiness_To_CommissionConfigsDto_Valide_Test()
        {
            var newFoodBusiness = foodBusiness;
            newFoodBusiness.CommissionConfigs = new CommissionConfigs
            {
                Value = 20,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusiness
            };

            var commissionConfigsDto = _mapper.Map<CommissionConfigsDto>(foodBusiness);
            Assert.Equal(foodBusiness.FoodBusinessId, commissionConfigsDto.FoodBusinessId);
            Assert.Equal(foodBusiness.DefaultCurrency, commissionConfigsDto.DefaultCurrency);
            Assert.Equal(foodBusiness.CommissionConfigs.Value, commissionConfigsDto.Value);
            Assert.Equal(foodBusiness.CommissionConfigs.Type, commissionConfigsDto.Type);
            Assert.Equal(foodBusiness.CommissionConfigs.WhoPay, commissionConfigsDto.WhoPay);
        }
    }
}