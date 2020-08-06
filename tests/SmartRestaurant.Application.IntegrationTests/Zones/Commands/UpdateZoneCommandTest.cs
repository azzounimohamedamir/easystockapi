using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Commands
{
    using static Testing;
    [TestFixture]
    public class UpdateZoneCommandTest : TestBase
    {
        [Test]
        public async Task CreateZone_ShouldSaved()
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
                ZoneTitle = "zone 51"
            };
            await SendAsync(createZoneCommand);
            var updateZoneCommand = new UpdateZoneCommand
            {
                CmdId = createZoneCommand.CmdId,
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 52"
            };
            var validationResult = await SendAsync(updateZoneCommand);
            var item = await FindAsync<Zone>(updateZoneCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            fastFood.Should().NotBeNull();
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            item.ZoneId.Should().Be(updateZoneCommand.CmdId);
            item.ZoneTitle.Should().Be(updateZoneCommand.ZoneTitle);
        }

    }
}
