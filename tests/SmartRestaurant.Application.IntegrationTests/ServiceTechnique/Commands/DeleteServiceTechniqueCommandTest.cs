using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.ServiceTechniqueDestination.Commands;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation
{
    using static Testing;

    [TestFixture]
    public class DeleteServiceTechniqueCommandTest : TestBase
    {
        [Test]
        public async Task DeleteServiceTechniqueCommandTest_ShouldRemoveFromDb()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createServiceTech = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);
            await SendAsync(new DeleteServiceTechniqueCommand {Id = createServiceTech.Id});
            var item = await FindAsync<Section>(createServiceTech.Id);
            item.Should().BeNull();
        }
    }
}