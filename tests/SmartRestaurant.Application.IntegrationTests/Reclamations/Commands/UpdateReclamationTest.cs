using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Reclamations
{
    using static Testing;

    [TestFixture]
    public class UpdateReclamationCommandTest : TestBase
    {

        [Test]
        public async Task UpdateReclamationCommand_ShouldUpdateInDB()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);

            var hotel = await HotelTestTools.CreateHotel(client.Id, "Sofitel");
            var building = await BuildingTestTools.CreateBuilding("building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);

            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            DateTime reclamationTime = new DateTime(2023, 3, 9, 16, 5, 7, 123);
            var serviceTechnique = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);

            var typereclamation = await ReclamationTestTools.CreateTypeReclamation("no wifi", hotel.Id, serviceTechnique.Id);
            ConfigureDateTimeNow(reclamationTime);
            var reclamation = await ReclamationTestTools.CreateReclamation(checkin.Id.ToString(), client.Id, hotel.Id, room.Id.ToString(),reclamationTime,typereclamation.Id);


            var updatereclamationcommand = new UpdateReclamationCommand
            {
               Id= reclamation.Id,
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                updatereclamationcommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "climatiseur.png");
                await SendAsync(updatereclamationcommand);
            };

            var item = await FindAsync<Domain.Entities.Reclamation>(updatereclamationcommand.Id);

            item.Should().NotBeNull();
          
            item.Id.Should().Be(updatereclamationcommand.Id);
        }
    }
}