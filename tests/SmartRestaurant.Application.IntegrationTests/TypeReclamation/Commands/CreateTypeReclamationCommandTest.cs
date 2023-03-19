using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.type
{
    using static Testing;

    [TestFixture]
    public class CreateTypeReclamationCommandTest : TestBase
    {
        [Test]
        public async Task CreateTypeReclamationCommandTest_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var serviceTechnique = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);

            var createTypeReclamationCommand = await ReclamationTestTools.CreateTypeReclamation("panne",hotel.Id,serviceTechnique.Id);
            var item = await FindAsync<Domain.Entities.TypeReclamation>(createTypeReclamationCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("panne");
            item.Names.AR.Should().Be("عطل");
            item.Names.EN.Should().Be("panne");
            item.Names.FR.Should().Be("panne");
            item.Names.TR.Should().Be("panne");
            item.Names.RU.Should().Be("panne");
            item.TypeReclamationId.Should().Be(createTypeReclamationCommand.Id);
        }
    }
}