using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Rooms.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteRoomTests : TestBase
    {
        [Test]
        public async Task Shoulremovebuilding()

        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Hotel Safir");
            var building = await BuildingTestTools.CreateBuilding("safirbuilding", hotelsafir.Id);
            var room1= await RoomTestTools.CreateRoom(1, building.Id);
            await SendAsync(new DeleteRoomCommand
            {
                Id = room1.Id
            });

            var roomdelete = await FindAsync<Domain.Entities.Room>(room1.Id);

            roomdelete.Should().BeNull();
        }
    }
}