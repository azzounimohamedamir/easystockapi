using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZonesListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllZonesList()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            for (var i = 0; i < 5; i++)
            {
                var name = "zone " + Guid.NewGuid();
                await SendAsync(new CreateZoneCommand
                {
                    FoodBusinessId = createFoodBusinessCommand.CmdId,
                    ZoneTitle = name
                });
            }

            var query = new GetZonesListQuery {FoodBusinessId = createFoodBusinessCommand.CmdId};

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}