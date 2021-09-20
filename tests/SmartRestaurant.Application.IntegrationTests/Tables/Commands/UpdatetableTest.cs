using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateTableTest : TestBase
    {
        [Test]
        public async Task UpdateTable_shouldBBeSaved()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand).ConfigureAwait(false);
            var zone = await FindAsync<Zone>(createZoneCommand.Id);
            var createTableCommand = new CreateTableCommand
            {
                Capacity = 4,
                ZoneId = zone.ZoneId.ToString(),
            };

            await SendAsync(createTableCommand);
            var updateTableCommand = new UpdateTableCommand
            {
                Id = createTableCommand.Id,
                Capacity = 10,
                TableNumber = 12,
                ZoneId = zone.ZoneId,
                TableState = 1
            };
            await SendAsync(updateTableCommand);
            var item = await FindAsync<Table>(updateTableCommand.Id);

            item.Should().NotBeNull();
            item.ZoneId.Should().Be(createZoneCommand.Id);
            item.Capacity.Should().Be(10);
            item.TableNumber.Should().Be(12);
            item.TableState.Should().Be(TableState.Occupied);
        }
    }
}