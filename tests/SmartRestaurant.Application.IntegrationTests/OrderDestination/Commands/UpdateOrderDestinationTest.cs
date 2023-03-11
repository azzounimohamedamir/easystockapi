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
    public class UpdateOrderDestinationCommandTest : TestBase
    {
        [Test]
        public async Task UpdateOrderDestinationCommand_ShouldUpdateInDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createOrderDestinationCommand = await OrderDestinationTestTools.CreateOrderDestination(hotel.Id); ;
            await SendAsync(new UpdateOrderDestinationCommand
            {
                Id = createOrderDestinationCommand.Id,
                HotelId = hotel.Id,
                Names = new Common.Dtos.ValueObjects.NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
            });
            var item = await FindAsync<Domain.Entities.OrderDestination>(createOrderDestinationCommand.Id);

            item.Should().NotBeNull();
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.OrderDestinationId.Should().Be(createOrderDestinationCommand.Id);
        }
    }
}