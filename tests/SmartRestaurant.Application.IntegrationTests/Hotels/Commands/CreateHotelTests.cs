using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateHotelTests : TestBase
    {
        [Test]
        public async Task CreateHotel_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();

            var createHotelCommand = new CreateHotelCommand
            {
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
                Odoo = new OdooDto
                {
                    Url = "smartrestaurantdb.odoo.com",
                    Username = "g22riecredential@gmail.com",
                    Password = "g22rie23032022",
                    Db = "smartrestaurantdb"
                },
                Description = "",

                Name = "MADINA HOTEL",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                NIF = 121115,
                NIS = 25544855,
                ImagUrl = "assets/dldldld",
                NRC = 485844,
                Email = "madina@hotel.dz",
                Website = "",
                YoutubeLink="234222",
                FoodBusinessAdministratorId = foodBusinessAdministrator.Id,
            };


            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createHotelCommand);
            };




            var item = await FindAsync<Domain.Entities.Hotel>(createHotelCommand.Id);

            item.Should().NotBeNull();
            item.FoodBusinessAdministratorId.Should().Be(foodBusinessAdministrator.Id);
            item.Name.Should().BeEquivalentTo(createHotelCommand.Name);
            item.Address.Should().BeEquivalentTo(createHotelCommand.Address);
            item.Description.Should().BeEquivalentTo(createHotelCommand.Description);
            item.ImagUrl.Should().BeEquivalentTo(createHotelCommand.ImagUrl);
            item.Address.City.Should().Be("Algiers");
            item.NIF.Should().Be(121115);
            item.NIS.Should().Be(25544855);
            item.NRC.Should().Be(485844);
            item.PhoneNumber.CountryCode.Should().Be(213);
            item.Email.Should().Contain("@");
            item.PhoneNumber.Number.Should().Be(670217536);

        }
    }
}