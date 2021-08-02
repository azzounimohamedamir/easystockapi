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
    public class UpdateZoneCommandTest : TestBase
    {
        [Test]
        public async Task CreateZone_ShouldSaved()
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
            var updateZoneCommand = new UpdateZoneCommand
            {
                Id = createZoneCommand.Id,
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 52"
            };
            await SendAsync(updateZoneCommand);
            var item = await FindAsync<Zone>(updateZoneCommand.Id);

            fastFood.Should().NotBeNull();
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            item.ZoneId.Should().Be(updateZoneCommand.Id);
            item.ZoneTitle.Should().Be(updateZoneCommand.ZoneTitle);
        }
    }
}