using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Reclamations.Commands
{
    using static Testing;
    public class DeleteReclamationTest:TestBase
    {
        [Test]

        public async Task DeleteReclamationCommand_ShouldDeletenDB()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);

            var hotel = await HotelTestTools.CreateHotel(client.Id, "Sofitel");
            var building = await BuildingTestTools.CreateBuilding("building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);

            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            DateTime reclamationTime = new DateTime(2023, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(reclamationTime);
            var reclamation = await ReclamationTestTools.CreateReclamation(checkin.Id.ToString(), client.Id, hotel.Id, room.Id.ToString(),reclamationTime);


            await SendAsync(new DeleteReclamationCommand { Id = reclamation.Id });




            var reclamationTodelete = await FindAsync<Domain.Entities.Reclamation>(reclamation.Id);

            reclamationTodelete.Should().BeNull();
        }

    }
}
