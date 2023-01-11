using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Application.Checkins.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class CheckInsTestTools
    {
        public static async Task<CheckIn> Create_Draft_Checkin( Guid hotelId)
        {

            var createCheckinCommand = new CreateCheckInCommand
            {
                hotelId = hotelId,
                RoomId = Guid.Empty,
                FullName = "",
                RoomNumber = 0,
                Email = "",
                PhoneNumber = "",
                IsActivate = false,
                ClientId = "",
                LengthOfStay = 0,
                Startdate = DateTime.Now
            };
            await SendAsync(createCheckinCommand);
            var checkin = await FindAsync<Domain.Entities.CheckIn>(createCheckinCommand.Id);
            return checkin;

        }
        public static async Task<CheckIn> CreateCheckinForClient(Guid hotelId,string clientId ,Guid roomId)
        {

            var createCheckinCommand = new CreateCheckInCommand
            {
                hotelId = hotelId,
                RoomId = roomId,
                FullName = "Client",
                RoomNumber = 2,
                Email = "ClientHotel@gmail.com",
                PhoneNumber = "0561279578",
                IsActivate = true,
                ClientId = clientId,
                LengthOfStay = 2,
                Startdate = DateTime.Now
            };
            await SendAsync(createCheckinCommand);
            var checkin = await FindAsync<Domain.Entities.CheckIn>(createCheckinCommand.Id);
            return checkin;

        }


    }
}