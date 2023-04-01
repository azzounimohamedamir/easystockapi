using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
	using static Testing;

	[TestFixture]
	public class CreateFoodBusinessWithOdooConfigTests : TestBase
	{
		[Test]
		public async Task CreateFoodBusinessWithOdooConfig_ShouldSaveToDB()
		{
			await RolesTestTools.CreateRoles();
			var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();

			var createFoodBusinessCommand = new CreateFoodBusinessCommand
			{
				AcceptsCreditCards = true,
				AcceptTakeout = true,
				IsMenuItemDetailed= false,
				Odoo= new OdooDto
				{
					Db="odooDb",
					Password="odooPassword",
					Url="odooDb.odoo.com",
					Username="ali@gmail.com"
				},
				Address = new AddressDto
				{
					City = "Algiers",
					Country = "Algeria",
					GeoPosition = new GeoPositionDto
					{
						Latitude = "0",
						Longitude = "0"
					},
					StreetAddress = "Didouche Mourad"
				},
				Description = "",
				HasCarParking = true,
				AcceptDelivery = true,
				IsHandicapFriendly = true,
				Name = "Taj mahal",
				OpeningTime = "11:00",
				ClosingTime = "23:00",
				NearbyLocationDescription = "alger",
				FarLocationDescription = "hors alger",
				FarLocationPrice = 600,
				NearbyLocationPrice = 300,      
				OffersTakeout = true,
				PhoneNumber = new PhoneNumberDto {CountryCode = 213, Number = 670217536},
				Tags = new List<string>
				{
					"",
					""
				},
				Email = "test@g22.com",
				Website = "",
				FoodBusinessAdministratorId = foodBusinessAdministrator.Id,
				FoodBusinessCategory = FoodBusinessCategory.Restaurant,
				DefaultCurrency = Currencies.USD
			};


			await SendAsync(createFoodBusinessCommand);

			var item = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);

			item.Should().NotBeNull();
			item.FoodBusinessId.Should().Be(createFoodBusinessCommand.Id);
			item.Name.Should().BeEquivalentTo(createFoodBusinessCommand.Name);
			item.Address.Should().BeEquivalentTo(createFoodBusinessCommand.Address);
			item.AcceptDelivery.Should().BeTrue();
			item.OpeningTime.Should().Be(createFoodBusinessCommand.OpeningTime);
			item.ClosingTime.Should().Be(createFoodBusinessCommand.ClosingTime);
			item.NearbyLocationDescription.Should().Be(createFoodBusinessCommand.NearbyLocationDescription);
			item.NearbyLocationPrice.Should().Be(createFoodBusinessCommand.NearbyLocationPrice);
			item.FarLocationDescription.Should().Be(createFoodBusinessCommand.FarLocationDescription);
			item.FarLocationPrice.Should().Be(createFoodBusinessCommand.FarLocationPrice);
			item.Odoo.Should().BeEquivalentTo(createFoodBusinessCommand.Odoo);// test odoo object
		}
	}
}