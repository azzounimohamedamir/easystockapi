using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;
using SmartRestaurant.Application.Zones.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Queries
{
    using static Testing;

    public class GetTablesListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllTablesList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);

            var rnd = new Random();
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateTableCommand
                {
                    ZoneId = createZoneCommand.Id.ToString(),
                    Capacity = rnd.Next(1, 5),
                });
            var query = new GetTablesListQuery {ZoneId = createZoneCommand.Id};

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}