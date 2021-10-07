using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class FoodBusinessClientTestTools
    {
        public static async Task<Domain.Entities.FoodBusinessClient> CreateFoodBusinessClient(string foodBusinessClientManagerId)
        {
            var createFoodBusinessClientCommand = new CreateFoodBusinessClientCommand
            {
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
                Name = "G22 REI",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Email = "test@g22.com",
                Website = "",
                ManagerId = foodBusinessClientManagerId
            };
            await SendAsync(createFoodBusinessClientCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);
            return fastFood;
        }

        public static async Task<Domain.Entities.FoodBusinessClient> CreateFoodBusinessClient(string foodBusinessClientManagerId, string foodBusinessClientName)
        {
            var createFoodBusinessClientCommand = new CreateFoodBusinessClientCommand
            {
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
                Name = foodBusinessClientName,
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Email = "test@g22.com",
                Website = "",
                ManagerId = foodBusinessClientManagerId
            };
            await SendAsync(createFoodBusinessClientCommand);
            var foodBusinessClient = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);
            return foodBusinessClient;
        }
    }
}
