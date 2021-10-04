using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task CreateFoodBusinessClient_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();

            var createFoodBusinessClientCommand = new CreateFoodBusinessClientCommand
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
                Description = "",
                Name = "G22 REI",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Email = "test@g22rei.com",
                Website = "http://g22rei.com",
                ManagerId = foodBusinessClientManager.Id
            };


            await SendAsync(createFoodBusinessClientCommand);

            var item = await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);

            item.Should().NotBeNull();
            item.FoodBusinessClientId.Should().Be(createFoodBusinessClientCommand.Id);
            item.Name.Should().BeEquivalentTo(createFoodBusinessClientCommand.Name);
            item.Address.Should().BeEquivalentTo(createFoodBusinessClientCommand.Address);
        }
    }
}
