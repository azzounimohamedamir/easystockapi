using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Tables.Queries;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Queries
{
    using static Testing;

    public class GetTableByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnTable()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand);
            var createTableCommand = new CreateTableCommand
            {
                ZoneId = createZoneCommand.Id,
                Capacity = 5,
                TableNumber = 10,
                TableState = 1
            };
            await SendAsync(createTableCommand);
            var query = new GetTableByIdQuery {TableId = createTableCommand.Id};

            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Capacity.Should().Be(5);
            result.TableState.Should().Be(TableState.Occupied);
            result.TableId.Should().Be(createTableCommand.Id);
        }
    }
}