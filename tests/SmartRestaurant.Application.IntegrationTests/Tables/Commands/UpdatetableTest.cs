using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Tables.Commands
{
    using static Testing;
    [TestFixture]
    public class UpdateTableTest : TestBase
    {
        [Test]
        public async Task UpdateTable_shouldBBeSaved()
        {
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                NameEnglish = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand).ConfigureAwait(false);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand).ConfigureAwait(false);
            var zone = await FindAsync<Zone>(createZoneCommand.CmdId);
            var createTableCommand = new CreateTableCommand
            {
                Capacity = 4,
                TableNumber = 10,
                ZoneId = zone.ZoneId,
                TableState = 0
            };

            await SendAsync(createTableCommand);
            var updateTableCommand = new UpdateTableCommand
            {
                CmdId = createTableCommand.CmdId,
                Capacity = 10,
                TableNumber = 12,
                ZoneId = zone.ZoneId,
                TableState = 1
            };
            var validationResult = await SendAsync(updateTableCommand);
            var item = await FindAsync<Table>(updateTableCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.ZoneId.Should().Be(createZoneCommand.CmdId);
            item.Capacity.Should().Be(10);
            item.TableNumber.Should().Be(12);
            item.TableState.Should().Be(TableState.Occupied);
        }
    }
}
