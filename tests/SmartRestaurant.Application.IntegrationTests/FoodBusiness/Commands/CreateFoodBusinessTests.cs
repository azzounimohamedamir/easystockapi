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
    public class CreateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task CreateFoodBusiness_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();

            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                AcceptsCreditCards = true,
                AcceptTakeout = true,
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
                IsHandicapFriendly = true,
                Name = "Taj mahal",
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
                FoodBusinessCategory = FoodBusinessCategory.Restaurant
            };


            await SendAsync(createFoodBusinessCommand);

            var item = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);

            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(createFoodBusinessCommand.Id);
            item.Name.Should().BeEquivalentTo(createFoodBusinessCommand.Name);
            item.Address.Should().BeEquivalentTo(createFoodBusinessCommand.Address);
        }
    }
}