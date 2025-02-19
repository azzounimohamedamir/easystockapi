﻿using System.Collections.Generic;
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
    public class ActivateCheckinTests : TestBase
    {
        [Test]
        public async Task ShouldActivateCheckinsByQrCode()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);
            var hotel= await HotelTestTools.CreateHotel(client.Id, "Shiraton");
            var checkin = await CheckInsTestTools.Create_Draft_Checkin(hotel.Id);


            await Task.Delay(0).ContinueWith(async t =>
            {
                var ActivateCheckin = new ActivateCheckinCommand
                {
                    Id = checkin.Id

                };

                await SendAsync(ActivateCheckin);

                var chechkinactivated = await FindAsync<Domain.Entities.CheckIn>(checkin.Id);

                chechkinactivated.Id.Should().Be(ActivateCheckin.Id);
                chechkinactivated.Email.Should().Be("ClientHotel@gmail.com");
                chechkinactivated.PhoneNumber.Should().Be("0561279578");
                chechkinactivated.FullName.Should().Be("Client");
                chechkinactivated.hotelId.Should().Be(hotel.Id);
                chechkinactivated.RoomNumber.Should().Be(0);
                chechkinactivated.ClientId.Should().Be(client.Id);

                chechkinactivated.RoomId.Should().Be(Guid.Empty);
                chechkinactivated.IsActivate.Should().Be(true);
                chechkinactivated.LengthOfStay.Should().Be(checkin.LengthOfStay);
                chechkinactivated.Startdate.Should().Be(checkin.Startdate);
            });

        }
    }
}