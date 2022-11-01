using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Commands
{
    using static Testing;

    public class UpdateHotelTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateHotel()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id,"Hotel Safir");


            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateHotelCommand = new UpdateHotelCommand
                {
                    Id = hotelsafir.Id.ToString(),
                   
                    Address = new AddressDto
                    {
                        City = "Boumerdes",
                        Country = "Algerie",
                        StreetAddress = "Cite 600 logement"
                    },
                    Description = "hotel 5 etoile situé au centre ville de boumerdes",
                    NIF = 15151522,
                    NIS = 15151523,
                    ImagUrl = "new image url for hotel",
                    NRC = 15152232,

                    Name = "Safir El Madina",
                    PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 553090200 },
                   
                    Email = "newsafir@safir.com",
                    Website = "http://www.safir.dz",
                    FoodBusinessAdministratorId = hotelsafir.FoodBusinessAdministratorId,
                };

                await SendAsync(updateHotelCommand);

                var list = await FindAsync<Domain.Entities.Hotel>(hotelsafir.Id);

                list.Id.Should().Be(updateHotelCommand.Id);
                list.Name.Should().Be("Safir El Madina");
                list.PhoneNumber.Number.Should().Be(553090200);
                list.PhoneNumber.CountryCode.Should().Be(213);

                list.Email.Should().Be("newsafir@safir.com");
                list.ImagUrl.Should().Be("new image url for hotel");
                list.NRC.Should().Be(15152232);
                list.NIF.Should().Be(15151523);
                list.NIS.Should().Be(15151523);
                list.Website.Should().Be("http://www.safir.dz");
                list.FoodBusinessAdministratorId.Should().Be(hotelsafir.FoodBusinessAdministratorId);
                list.Description.Should().Be("hotel 5 etoile situé au centre ville de boumerdes");
                list.Address.StreetAddress.Should().Be("Cite 600 logement");
                list.Address.City.Should().Be("Boumerdes");
                list.Address.Country.Should().Be("Algerie");
            });
        }
    }
}