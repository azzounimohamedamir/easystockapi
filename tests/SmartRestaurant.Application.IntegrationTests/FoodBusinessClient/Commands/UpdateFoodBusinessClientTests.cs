using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;


namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Commands
{
    using static Testing;
    public class UpdateFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateFoodBusinessClient()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var foodBusinessClient = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);


            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFoodBusinessClientCommand = new UpdateFoodBusinessClientCommand
                {
                    Id = foodBusinessClient.ManagerId.ToString(),
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
                    Name = "G22 REI Updated test",
                    PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                    Email = "test@g22.com",
                    Website = "",
                    ManagerId = foodBusinessClient.ManagerId,
                };

                await SendAsync(updateFoodBusinessClientCommand);

                var list = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);

                list.FoodBusinessClientId.Should().Be(updateFoodBusinessClientCommand.Id);
                list.Name.Should().Be("G22 REI Updated test");
            });
        }
    }
}
