
using System.Threading.Tasks;
using FluentAssertions;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Rooms.Queries;
using NUnit.Framework;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Queries
{
    using static Testing;
    public class GetAllRoomsByBuildingIdTest : TestBase
    {
        [Test]
        public async Task shouldReturnAllRoomsByuildingId()
        {
            await RolesTestTools.CreateRoles();

            var foodBusinessAdmin = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel1 = await HotelTestTools.CreateHotel(foodBusinessAdmin.Id, "sofitel");

            var building1_hotel1 = await BuildingTestTools.CreateBuilding("building1_hotel1", hotel1.Id);
            var building2_hotel1 = await BuildingTestTools.CreateBuilding("building2_hotel1", hotel1.Id);
            var room1_building1 = await RoomTestTools.CreateRoom(1, building1_hotel1.Id);
            var room2_building1 = await RoomTestTools.CreateRoom(2, building1_hotel1.Id);
            var room3_building1 = await RoomTestTools.CreateRoom(3, building1_hotel1.Id);
            var room1_building2 = await RoomTestTools.CreateRoom(1, building2_hotel1.Id);



            var query = new GetAllRoomsByBuildingId
            {
                BuildingId = building1_hotel1.Id,
                Page = 1,
                PageSize = 5,
            };
            var listofRoomsOfBuilding1 = await SendAsync(query);

            listofRoomsOfBuilding1.Data[0].RoomNumber= room1_building1.RoomNumber;
            listofRoomsOfBuilding1.Data[1].RoomNumber = room2_building1.RoomNumber;
            listofRoomsOfBuilding1.Data[2].RoomNumber = room3_building1.RoomNumber;

            listofRoomsOfBuilding1.Data.Should().HaveCount(3);
        }
    }
}
