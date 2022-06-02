using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZoneByIdTest : TestBase
    {
        [Test]
        public async Task ShouldReturnZoneById()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var name = "zone " + Guid.NewGuid();
            var createZoneCommand=await ZoneTestTools.CreateZone(fastFood, name);

            var item = await SendAsync(new GetZoneByIdQuery {ZoneId = createZoneCommand.Id});
            item.Should().NotBeNull();
            item.ZoneTitle.Should().Be(name);
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
        }
    }
}