using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteZoneCommandTest : TestBase
    {
        [Test]
        public async Task DeleteZoneTask()
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
                ZoneTitle = "zone 51"
            };
            await SendAsync(createZoneCommand);
            var deleteCommand = new DeleteZoneCommand {Id = createZoneCommand.Id};
            await SendAsync(deleteCommand);
            var zone51 = await FindAsync<Zone>(createZoneCommand.Id);
            zone51.Should().BeNull();
        }
    }
}