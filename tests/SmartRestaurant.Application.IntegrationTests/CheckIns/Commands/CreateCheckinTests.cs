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

namespace SmartRestaurant.Application.IntegrationTests.CheckIns.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateCheckinTests : TestBase
    {
        [Test]
        public async Task CreateCheckinDraft_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel= await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Shiraton");
            var checkin = await CheckInsTestTools.Create_Draft_Checkin(hotel.Id);

            var createdcheckin = await FindAsync<CheckIn>(checkin.Id);


            createdcheckin.Should().NotBeNull();
            createdcheckin.hotelId.Should().Be(hotel.Id);
            createdcheckin.RoomNumber.Should().Be(0);
            createdcheckin.ClientId.Should().Be("");
            createdcheckin.Email.Should().Be("");
            createdcheckin.RoomId.Should().Be(Guid.Empty);
            createdcheckin.IsActivate.Should().Be(false);
            createdcheckin.LengthOfStay.Should().Be(0);
            createdcheckin.PhoneNumber.Should().Be("");
            createdcheckin.Startdate.Should().Be(checkin.Startdate);

        }
    }
}