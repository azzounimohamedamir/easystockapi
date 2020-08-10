using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;
using SmartRestaurant.Application.Zones.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Queries
{
    using static Testing;
    public class GetTablesListTests
    {
        [Test]
        public async Task ShouldReturnAllTablesList()
        {
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                NameEnglish = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand);
            var rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                await SendAsync(new CreateTableCommand
                {
                    ZoneId = createZoneCommand.CmdId,
                    Capacity = rnd.Next(1,5),
                    TableNumber = i + 1,
                    TableState =(short) rnd.Next(0,2)

                });
            }
            var query = new GetTablesListQuery(){ZoneId = createZoneCommand.CmdId};

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}
