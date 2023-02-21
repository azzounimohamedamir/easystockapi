
using System.Threading.Tasks;
using FluentAssertions;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Reclamation.Queries;
using NUnit.Framework;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.IntegrationTests.Reclamations.Queries
{
    using static Testing;
    public class GetAllReclamationListQueryTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllReclamationListTestShouldHaveBothOfHotelsreclamations()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);

            var hotel = await HotelTestTools.CreateHotel(client.Id, "sofitel");
            var building = await BuildingTestTools.CreateBuilding("building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);
            var hotel2 = await HotelTestTools.CreateHotel(client.Id, "Najma");
            var building2 = await BuildingTestTools.CreateBuilding("building2", hotel2.Id);
            var room2 = await RoomTestTools.CreateRoomForClient(5, building2.Id, client.Id);
            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            var checkin2 = await CheckInsTestTools.CreateCheckinForClient(hotel2.Id, client.Id, room2.Id);

            DateTime reclamationTime = new DateTime(2023, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(reclamationTime);
            var reclamationFromHotel1 = await ReclamationTestTools.CreateReclamation(checkin.Id.ToString(),client.Id, hotel.Id, room.Id.ToString(),reclamationTime);
            var reclamationFromHotel2 = await ReclamationTestTools.CreateReclamation(checkin2.Id.ToString(),client.Id, hotel2.Id, room2.Id.ToString(),reclamationTime) ;


            var query = new GetAllReclamationOfClientQuery
            {
                Page = 1,
                PageSize = 5,
            };
            var listofReclamation = await SendAsync(query);
            listofReclamation.Data.Should().HaveCount(2);
            listofReclamation.Data[0].BuildingName.Should().Be(building.Name);
            listofReclamation.Data[0].ClientEmail.Should().Be(room.ClientEmail);
            listofReclamation.Data[0].ClientName.Should().Be(checkin.FullName);
            listofReclamation.Data[0].ClientPhone.Should().Be(checkin.PhoneNumber);
            listofReclamation.Data[0].CreatedAt.Should().Be(reclamationFromHotel1.CreatedAt);
            listofReclamation.Data[0].ReclamationDescription.AR.Should().Be("عطل");
            listofReclamation.Data[0].ReclamationDescription.EN.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.FR.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.TR.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.RU.Should().Be("panne");

            listofReclamation.Data[1].BuildingName.Should().Be(building2.Name);
            listofReclamation.Data[1].ClientEmail.Should().Be(room2.ClientEmail);
            listofReclamation.Data[1].ClientName.Should().Be(checkin2.FullName);
            listofReclamation.Data[1].ClientPhone.Should().Be(checkin2.PhoneNumber);
            listofReclamation.Data[1].CreatedAt.Should().Be(reclamationFromHotel2.CreatedAt);
            listofReclamation.Data[1].ReclamationDescription.AR.Should().Be("عطل");
            listofReclamation.Data[1].ReclamationDescription.EN.Should().Be("panne");
            listofReclamation.Data[1].ReclamationDescription.FR.Should().Be("panne");
            listofReclamation.Data[1].ReclamationDescription.TR.Should().Be("panne");
            listofReclamation.Data[1].ReclamationDescription.RU.Should().Be("panne");

        }
    }
}
