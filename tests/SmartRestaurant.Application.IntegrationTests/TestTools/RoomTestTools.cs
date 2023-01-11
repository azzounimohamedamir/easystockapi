using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Rooms.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class RoomTestTools
    {
        public static async Task<Domain.Entities.Room> CreateRoom(int roomnumber, Guid buildingId)
        {
            var roomComand = new CreateRoomCommand()
            {
                BuildingId = buildingId,
                RoomNumber = roomnumber,
                FloorNumber = 2,
                ClientEmail = "test@gmail.com",
                IsBooked = false
          

            };

            await SendAsync(roomComand);

            var room = await FindAsync<Domain.Entities.Room>(roomComand.Id);
            return room;
        }
        public static async Task<Domain.Entities.Room> CreateRoomForClient(int roomnumber, Guid buildingId ,string clientId)
        {
            var roomComand = new CreateRoomCommand()
            {
                BuildingId = buildingId,
                RoomNumber = roomnumber,
                FloorNumber = 2,
                ClientEmail = "test@gmail.com",
                IsBooked = false,
                ClientId= clientId

            };

            await SendAsync(roomComand);

            var room = await FindAsync<Domain.Entities.Room>(roomComand.Id);
            return room;
        }

    }
}