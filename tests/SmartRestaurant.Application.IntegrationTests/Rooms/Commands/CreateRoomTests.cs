
using System.Threading.Tasks;
using FluentAssertions;

using NUnit.Framework;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.Rooms.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateRoomTests : TestBase
    {
        [Test]
        public async Task CreateRoom_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel= await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Shiraton");
            var building= await BuildingTestTools.CreateBuilding("building 01",hotel.Id);
             

            var createRoomCommand = new CreateRoomCommand
            {
                BuildingId = building.Id,
                RoomNumber = 2,
                NumberOfBeds = 1,
                FloorNumber = 2,
                ClientEmail = "amir@gmail.com",
                IsBooked=true
            };
            await SendAsync(createRoomCommand);

            var item = await FindAsync<Domain.Entities.Room>(createRoomCommand.Id);

            item.Should().NotBeNull();
            item.BuildingId.Should().Be(building.Id);
            item.ClientEmail.Should().BeEquivalentTo(createRoomCommand.ClientEmail);
            item.IsBooked.Should().BeTrue();
            item.RoomNumber.Should().Be(2);
            item.FloorNumber.Should().Be(2);
            item.NumberOfBeds.Should().Be(1);
        }
    }
}