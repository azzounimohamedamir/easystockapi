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
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
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
                FoodBusinessId = fastFood.FoodBusinessId.ToString()
            };
            await SendAsync(createFoodBusinessClientCommand);
            var foodBusinessClient = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);
            return foodBusinessClient;
        }

        public static async Task<Domain.Entities.FoodBusinessClient> CreateFoodBusinessClient(string foodBusinessClientManagerId, string foodBusinessClientName)
        {
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
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
                FoodBusinessId = fastFood.FoodBusinessId.ToString()
            };
            await SendAsync(createFoodBusinessClientCommand);
            var foodBusinessClient = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);
            return foodBusinessClient;
        }
    }
}
