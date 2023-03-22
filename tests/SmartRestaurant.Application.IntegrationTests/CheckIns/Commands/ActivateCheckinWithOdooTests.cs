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
using SmartRestaurant.Application.Rooms.Commands;
using Google.Api;

namespace SmartRestaurant.Application.IntegrationTests.CheckIns.Commands
{
	using static Testing;
	[TestFixture]
	public class ActivateCheckinWithOdooTests : TestBase
	{
		[Test]
		public async Task ShouldActivateCheckinsByQrCode()
		{
			await RolesTestTools.CreateRoles();
			var client = await UsersTestTools.CreateClient(_authenticatedUserId);
			var hotel= await HotelTestTools.CreateHotel(client.Id, "Shiraton");

            var building = await BuildingTestTools.CreateBuilding("building 01", hotel.Id);

            var createRoomCommand = new CreateRoomCommand
			{
						BuildingId = building.Id,
						RoomNumber = 2,
						NumberOfBeds = 1,
						FloorNumber = 2,
						Price = 400,
						ClientEmail = "ali@gmail.com",
						IsBooked=true
					};
			await SendAsync(createRoomCommand);
			var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id,client.Id,createRoomCommand.Id);

			await Task.Delay(0).ContinueWith(async t =>
			{
                var assignroomcommand = new UpdateCheckInAssignRoomCommand
                {
                    Id = checkin.Id,
                    RoomId = createRoomCommand.Id,
                    RoomNumber = 2,
                    LengthOfStay = 2,
                    Startdate = DateTime.Now
                };

                await SendAsync(assignroomcommand);

               

				var chechkinactivated = await FindAsync<Domain.Entities.CheckIn>(checkin.Id);

				chechkinactivated.Id.Should().Be(assignroomcommand.Id);
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