using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Commands
{
    using static Testing;

    public class UpdateRoomStatusTests : TestBase
    {
        [Test]
        public async Task ShouldReleaseRoom()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Hotel Safir");
            var building = await BuildingTestTools.CreateBuilding("safirbuilding", hotelsafir.Id);
            var room1 = await RoomTestTools.CreateRoom(1, building.Id);
            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateRoomCommand = new UpdateRoomCommand
                {


                    RoomNumber = 5,
                    FloorNumber = 2,
                    isBooked = true,
                    ClientEmail = "amir@gmail.com",
                    Price = 400


                };

                await SendAsync(updateRoomCommand);
                var list = await FindAsync<Domain.Entities.Room>(room1.Id);


                var LibererRoomCommand = new UpdateRoomStatusCommand
                {
                    Id=list.Id.ToString()
                };

                await SendAsync(LibererRoomCommand);

                var listafterLiber = await FindAsync<Domain.Entities.Room>(list.Id);
                listafterLiber.IsBooked = false;


            });
            
              


              

           
        }
    }
}