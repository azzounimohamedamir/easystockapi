using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Commands
{
    using static Testing;
    [TestFixture]
    class ArchiveFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task ShouldArchiveFoodBusinessClient()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var foodBusinessClient = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);

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
                    Archived = false

                };
                await SendAsync(createFoodBusinessClientCommand);
                var list = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);
                var archiveFoodBusinessClientCommand = new ArchiveFoodBusinessClientCommand
                {
                    Archived = true
                };

                await SendAsync(archiveFoodBusinessClientCommand);
                var archivedFoodBusinessClient = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);

                archivedFoodBusinessClient.Archived.Should().Be(archiveFoodBusinessClientCommand.Archived);

            });
        }
    }
}
