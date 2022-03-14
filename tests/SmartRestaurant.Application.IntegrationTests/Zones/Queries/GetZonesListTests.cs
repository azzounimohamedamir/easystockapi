using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZonesListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllZonesList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 5; i++)
            {
                var name = "zone " + Guid.NewGuid();
                await SendAsync(new CreateZoneCommand
                {
                    FoodBusinessId = fastFood.FoodBusinessId,
                    ZoneTitle = name
                });
            }

            var query = new GetZonesListQuery {FoodBusinessId = fastFood.FoodBusinessId};

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}