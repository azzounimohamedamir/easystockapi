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
    public class CreateZoneCommandTest : TestBase
    {
        [Test]
        public async Task CreateZone_ShouldSaved()
        {
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 51"
            };
            var validationResult = await SendAsync(createZoneCommand);

            var item = await FindAsync<Zone>(createZoneCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            fastFood.Should().NotBeNull();
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            item.ZoneId.Should().Be(createZoneCommand.CmdId);
            item.ZoneTitle.Should().Be(createZoneCommand.ZoneTitle);
        }
    }
}
