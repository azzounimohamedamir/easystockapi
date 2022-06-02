using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
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
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);

            var deleteCommand = new DeleteZoneCommand {Id = createZoneCommand.Id};
            await SendAsync(deleteCommand);
            var zone51 = await FindAsync<Zone>(createZoneCommand.Id);
            zone51.Should().BeNull();
        }
    }
}