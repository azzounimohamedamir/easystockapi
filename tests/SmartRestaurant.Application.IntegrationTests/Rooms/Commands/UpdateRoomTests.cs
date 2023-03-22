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

	public class UpdateRoomTests : TestBase
	{
		[Test]
		public async Task ShouldUpdateRoom()
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
					isBooked=true,
					ClientEmail="amir@gmail.com",
					Price = 400


				};

				await SendAsync(updateRoomCommand);

				var list = await FindAsync<Domain.Entities.Room>(room1.Id);

				list.Id.Should().Be(updateRoomCommand.Id);
				list.RoomNumber.Should().Be(5);
				list.ClientEmail.Should().Be("amir@gmail.com");
				list.FloorNumber.Should().Be(2);
				list.Price.Should().Be(400);
				list.IsBooked = true;

			});
		}
	}
}