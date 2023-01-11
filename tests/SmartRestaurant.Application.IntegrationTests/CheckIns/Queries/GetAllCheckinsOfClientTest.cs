using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Checkins.Queries;
using System;
using System.Threading.Tasks;

using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.CheckIns.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllCheckinsOfClientTest : TestBase
    {
        [Test]
        public async Task ShouldGetCheckinsListByClientTest()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);
            var hotel = await HotelTestTools.CreateHotel(client.Id, "Shiraton");
            var building = await BuildingTestTools.CreateBuilding("Building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);
            var checkin1 = await CheckInsTestTools.CreateCheckinForClient(hotel.Id,client.Id,room.Id);
          


            var query = new GetCheckinsListOfClientQuery
            {
                Page = 1,
                PageSize = 5,
            };


            var checkinsOfClient = await SendAsync(query);

            checkinsOfClient.Data.Count.Should().Be(1);
            checkinsOfClient.Data[0].hotelName.Should().Be(hotel.Name);
            checkinsOfClient.Data[0].ClientId.Should().Be(client.Id);
            checkinsOfClient.Data[0].RoomId.Should().Be(room.Id);
            checkinsOfClient.Data[0].buildingName.Should().Be(building.Name);
            checkinsOfClient.Data[0].FullName.Should().Be(client.FullName);
            checkinsOfClient.Data[0].IsActivate.Should().BeTrue();
            checkinsOfClient.Data[0].RoomNumber.Should().Be(2);
            checkinsOfClient.Data[0].LengthOfStay.Should().Be(2);
            checkinsOfClient.Data[0].PhoneNumber.Should().Be(client.PhoneNumber);
            checkinsOfClient.Data[0].Id.Should().Be(checkin1.Id);
           



        }
    }
}
