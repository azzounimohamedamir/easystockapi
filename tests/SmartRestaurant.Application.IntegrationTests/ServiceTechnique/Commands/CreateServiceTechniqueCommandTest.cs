using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.ServiceTechniqueDestination.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.type
{
    using static Testing;

    [TestFixture]
    public class CreateServiceTechniqueCommandTest : TestBase
    {
        [Test]
        public async Task CreateServiceTechniqueCommandTest_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");

            var createServiceTechniqueCommand = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);
            var item = await FindAsync<Domain.Entities.ServiceTechnique>(createServiceTechniqueCommand.Id);

            item.Should().NotBeNull();
            item.Names.AR.Should().Be("الترصيص و الصيانة");
            item.Names.EN.Should().Be("Plomberie");
            item.Names.FR.Should().Be("Plomberie");
            item.Names.TR.Should().Be("Plomberie");
            item.Names.RU.Should().Be("Plomberie");
            item.HotelId.Should().Be(hotel.Id);
        }
    }
}