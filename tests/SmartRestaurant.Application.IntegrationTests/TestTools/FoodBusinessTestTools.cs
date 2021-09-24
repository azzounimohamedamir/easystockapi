using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class FoodBusinessTestTools
    {
        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {             
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
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
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Tags = new List<string>
                {
                    "pizza",
                    "halal"
                },
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                DefaultCurrencyId = Guid.NewGuid()
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }

        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness(string foodBusinessAdministratorId)
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {              
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
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
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Tags = new List<string>
                {
                    "pizza",
                    "halal"
                },
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
                FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                DefaultCurrencyId = Guid.NewGuid()
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }

        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness(string foodBusinessAdministratorId, string foodBusinessName)
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                HasCarParking = true,
                IsHandicapFriendly = true,
                Name = foodBusinessName,
                OffersTakeout = true,
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Tags = new List<string>
                {
                    "pizza",
                    "halal"
                },
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
                FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                DefaultCurrencyId = Guid.NewGuid()
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }
    }
}