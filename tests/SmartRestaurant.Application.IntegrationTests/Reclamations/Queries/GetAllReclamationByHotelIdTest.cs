
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
    public class GetAllReclamationByHotelIdTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllReclamationByHotelIdTest()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);

            var hotel = await HotelTestTools.CreateHotel(client.Id, "sofitel");
            var building = await BuildingTestTools.CreateBuilding("building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);

            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            DateTime reclamationTime = new DateTime(2023, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(reclamationTime);
            var reclamation = await ReclamationTestTools.CreateReclamation(checkin.Id.ToString(),client.Id, hotel.Id, room.Id.ToString(),reclamationTime);


            var query = new GetAllReclamationListQuery
            {
                HotelId = hotel.Id.ToString(),
                Page = 1,
                PageSize = 5,
            };
            var listofReclamation = await SendAsync(query);
            listofReclamation.Data.Should().HaveCount(1);
            listofReclamation.Data[0].HotelName.Should().Be(hotel.Name);
            listofReclamation.Data[0].BuildingName.Should().Be(building.Name);
            listofReclamation.Data[0].ClientEmail.Should().Be(room.ClientEmail);
            listofReclamation.Data[0].ClientName.Should().Be(checkin.FullName);
            listofReclamation.Data[0].ClientPhone.Should().Be(checkin.PhoneNumber);
            listofReclamation.Data[0].CreatedAt.Should().Be(reclamationTime);
            listofReclamation.Data[0].ReclamationDescription.AR.Should().Be("عطل");
            listofReclamation.Data[0].ReclamationDescription.EN.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.FR.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.TR.Should().Be("panne");
            listofReclamation.Data[0].ReclamationDescription.RU.Should().Be("panne");

        }
    }
}
