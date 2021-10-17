using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;


namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Commands
{
    using static Testing;
    [TestFixture]
    public class UpdateFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateFoodBusinessClient()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var foodBusinessClient = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            await Task.Delay(0).ContinueWith(async t =>
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
                    Name = "G22 REI ",
                    PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                    Email = "test@g22.com",
                    Website = "",
                    ManagerId = foodBusinessClient.ManagerId,
                    FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                    Archived = false
                };
                await SendAsync(createFoodBusinessClientCommand);
                var list = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);
                var updateFoodBusinessClientCommand = new UpdateFoodBusinessClientCommand
                {
                    Id = foodBusinessClient.ManagerId.ToString(),
                    Address = new AddressDto
                    {
                        City = "Alger",
                        Country = "Algerie",
                        GeoPosition = new GeoPositionDto
                        {
                            Latitude = "0",
                            Longitude = "0"
                        },
                        StreetAddress = "Didouche Mourad"
                    },
                    Description = "Updated Description",
                    Name = "G22 REI Updated test",
                    PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 672217426 },
                    Email = "testUpdate@g22.com",
                    Website = "http://g22rei.com",
                    ManagerId = foodBusinessClient.ManagerId,
                    FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                    Archived = false
                };

                await SendAsync(updateFoodBusinessClientCommand);
                var updatesList = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);

                updatesList.FoodBusinessClientId.Should().Be(updateFoodBusinessClientCommand.Id);
                updatesList.Address.Should().Be(updateFoodBusinessClientCommand.Address);
                updatesList.Description.Should().BeEquivalentTo(updateFoodBusinessClientCommand.Description);
                updatesList.Name.Should().BeEquivalentTo(updateFoodBusinessClientCommand.Name);
                updatesList.PhoneNumber.Should().Be(updateFoodBusinessClientCommand.PhoneNumber);
                updatesList.Email.Should().Be(updateFoodBusinessClientCommand.Email);
                updatesList.Website.Should().Be(updateFoodBusinessClientCommand.Website);
                updatesList.ManagerId.Should().Be(updateFoodBusinessClientCommand.ManagerId);
                updatesList.FoodBusinessId.Should().Be(updateFoodBusinessClientCommand.FoodBusinessId);
            });
        }
    }
}
