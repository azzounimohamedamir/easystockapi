using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Reclamations.Commands
{
    using static Testing;

    public class CreateReclamationTest :TestBase
    {
        [Test]

        public async Task CreateReclamation_ShouldSaveToDb()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);
            
            var hotel = await HotelTestTools.CreateHotel(client.Id,"sofitel");
            var building = await BuildingTestTools.CreateBuilding("building1",hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);
           
            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id,client.Id,room.Id);
            DateTime reclamationTime = new DateTime(2023, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(reclamationTime);
            var reclamation = await ReclamationTestTools.CreateReclamation(checkin.Id.ToString(),client.Id, hotel.Id, room.Id.ToString() , reclamationTime);

            reclamation.ReclamationDescription.AR.Should().Be("عطل");
            reclamation.ReclamationDescription.FR.Should().Be("panne");
            reclamation.ReclamationDescription.EN.Should().Be("panne");
            reclamation.ReclamationDescription.TR.Should().Be("panne");
            reclamation.ReclamationDescription.RU.Should().Be("panne");

            reclamation.ClientId.Should().Be(client.Id);
            reclamation.RoomId.Should().Be(room.Id);
            reclamation.CreatedAt.Should().Be(reclamationTime);

        }
    }
}
