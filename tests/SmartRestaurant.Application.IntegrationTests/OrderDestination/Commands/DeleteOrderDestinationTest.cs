using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.OrderDestination.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.OrderDestination
{
    using static Testing;

    [TestFixture]
    public class DeleteOrderDestinationCommandTest : TestBase
    {
        [Test]
        public async Task DeleteOrderDestination_ShouldRemoveFromDb()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createOrderDestination = await OrderDestinationTestTools.CreateOrderDestination(hotel.Id);
            await SendAsync(new DeleteOrderDestinationCommand { Id = createOrderDestination.Id });
            var item = await FindAsync<Domain.Entities.OrderDestination>(createOrderDestination.Id);
            item.Should().BeNull();
        }
    }
}