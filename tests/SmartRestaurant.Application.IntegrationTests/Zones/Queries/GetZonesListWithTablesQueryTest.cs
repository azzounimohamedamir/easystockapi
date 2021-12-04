using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZonesListWithTablesQueryTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllZonesListWithTables()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 2; i++)
            {
                var name = "zone " + Guid.NewGuid();

                var createZoneCommand = new CreateZoneCommand
                {
                    FoodBusinessId = fastFood.FoodBusinessId,
                    ZoneTitle = name
                };
                await SendAsync(createZoneCommand);
                var zone = await FindAsync<Zone>(createZoneCommand.Id);
                var createTableCommand = new CreateTableCommand
                {
                    Capacity = 4,
                    ZoneId = zone.ZoneId.ToString(),
                };
                await SendAsync(createTableCommand);
                var createTableCommand2 = new CreateTableCommand
                {
                    Capacity = 4,
                    ZoneId = zone.ZoneId.ToString(),
                };
                await SendAsync(createTableCommand2);


            }
            var query = new GetZonesListWithTablesQuery { FoodBusinessId = fastFood.FoodBusinessId};
            var result = await SendAsync(query);
            result.Should().HaveCount(2);
            foreach (var item in result)    
            {
                item.Tables.Should().HaveCount(2);
            }
        }
    }
}