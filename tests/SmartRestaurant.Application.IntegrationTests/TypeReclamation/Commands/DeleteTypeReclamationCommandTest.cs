using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation
{
    using static Testing;

    [TestFixture]
    public class DeleteTypeReclamationCommandTest : TestBase
    {
        [Test]
        public async Task DeleteTypeReclamation_ShouldRemoveFromDb()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createTypeReclamation = await ReclamationTestTools.CreateTypeReclamation("Panne",hotel.Id);
            await SendAsync(new DeleteTypeReclamationCommand {Id = createTypeReclamation.Id});
            var item = await FindAsync<Section>(createTypeReclamation.Id);
            item.Should().BeNull();
        }
    }
}