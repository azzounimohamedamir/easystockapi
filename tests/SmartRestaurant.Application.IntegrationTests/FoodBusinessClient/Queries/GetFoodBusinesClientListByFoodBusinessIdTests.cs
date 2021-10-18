using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Queries
{
    using static Testing;

    public class GetFoodBusinesClientListByFoodBusinessIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessClientByFoodBusinessIdList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();

            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 5; i++)
            {
                var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
                var name = "Client " + i;
                await SendAsync(
                  new CreateFoodBusinessClientCommand
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
                    Name = name,
                     PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                    Email = "test"+i+"@g22.com",
                    Website = "",
                    ManagerId = foodBusinessClientManager.Id,
                    FoodBusinessId = fastFood.FoodBusinessId.ToString()
                });
            }

            var query = new GetFoodBusinesClientListByFoodBusinessIdQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString() };

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}
