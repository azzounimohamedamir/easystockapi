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
    public class UpdateZoneCommandTest : TestBase
    {
        [Test]
        public async Task UpdateZone_ShouldUpdated()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);

            var updateZoneCommand = new UpdateZoneCommand
            {
                Id = createZoneCommand.Id,
                FoodBusinessId = fastFood.FoodBusinessId,
                Names = new Common.Dtos.ValueObjects.NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
                ZoneTitle = "zone 52"
            };
            await SendAsync(updateZoneCommand);
            var item = await FindAsync<Zone>(updateZoneCommand.Id);

            fastFood.Should().NotBeNull();
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            item.ZoneId.Should().Be(updateZoneCommand.Id);
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
        }
    }
}