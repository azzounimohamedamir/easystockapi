using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Hotels.Commands;
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
            List<IFormFile> formFiles = new List<IFormFile>();
           
            string picture ="Building.jpeg";

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
        }
    }
}