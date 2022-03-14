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
    public class CreateFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task CreateFoodBusinessClient_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
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
                Email = "test@g22rei.com",
                Website = "http://g22rei.com",
                FoodBusinessId = fastFood.FoodBusinessId.ToString()
            };


            await SendAsync(createFoodBusinessClientCommand);

            var item = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);

            item.Should().NotBeNull();
            item.FoodBusinessClientId.Should().Be(createFoodBusinessClientCommand.Id);
            item.Name.Should().BeEquivalentTo(createFoodBusinessClientCommand.Name);
            item.Address.Should().BeEquivalentTo(createFoodBusinessClientCommand.Address);
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
        }
    }
}
