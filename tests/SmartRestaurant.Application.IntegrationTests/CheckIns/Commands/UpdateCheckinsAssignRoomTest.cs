using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SmartRestaurant.Application.Checkins.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;

using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Text.RegularExpressions;
using SmartRestaurant.Application.HotelSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Hotels.Commands;

namespace SmartRestaurant.Application.IntegrationTests.CheckIns.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateCheckinsAssignRoomTest : TestBase
    {
        [Test]
        public async Task ShouldActivateCheckinsByQrCode()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Shiraton");
            var checkin = await CheckInsTestTools.Create_Draft_Checkin(hotel.Id);


            await Task.Delay(0).ContinueWith(async t =>
            {
                var assignroomcommand = new UpdateCheckInAssignRoomCommand
                {
                    Id = checkin.Id,
                    RoomId = Guid.NewGuid(),
                    RoomNumber = 2,
                    LengthOfStay = 2,
                    Startdate=DateTime.Now
                };

                await SendAsync(assignroomcommand);

                var checkinafetassignroom = await FindAsync<Domain.Entities.CheckIn>(checkin.Id);

                checkinafetassignroom.Id.Should().Be(checkinafetassignroom.Id);
                checkinafetassignroom.Email.Should().Be("FoodBusinessAdministrator@bv.com");
                checkinafetassignroom.PhoneNumber.Should().Be("077654656");
                checkinafetassignroom.FullName.Should().Be("FoodBusinessAdministrator");
                checkinafetassignroom.hotelId.Should().Be(hotel.Id);
                checkinafetassignroom.RoomNumber.Should().Be(2);
                checkinafetassignroom.ClientId = "";
                checkinafetassignroom.RoomId.Should().Be(assignroomcommand.RoomId.ToString());
                checkinafetassignroom.IsActivate.Should().Be(false);
                checkinafetassignroom.LengthOfStay = 2;
                checkinafetassignroom.Startdate = DateTime.Now;
            });

        }
    }
}