using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateTableTest : TestBase
    {
        [Test]
        public async Task CreateTable_ShouldSaveToDB()
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
            var zone = await FindAsync<Zone>(createZoneCommand.Id);
            var createTableCommand = new CreateTableCommand
            {
                Capacity = 4,
                TableNumber = 10,
                ZoneId = zone.ZoneId,
                TableState = 0
            };
            await SendAsync(createTableCommand);
            var item = await FindAsync<Table>(createTableCommand.Id);

            item.Should().NotBeNull();
            item.ZoneId.Should().Be(createZoneCommand.Id);
            item.Capacity.Should().Be(4);
            item.TableNumber.Should().Be(10);
        }
    }
}