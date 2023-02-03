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

    public class UpdateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateFoodBusiness()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFoodBusinessCommand = new UpdateFoodBusinessCommand
                {
                    Id = fastFood.FoodBusinessId.ToString(),
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
                    AcceptDelivery = true,
                    IsHandicapFriendly = true,
                    Name = "Taj mahal Updated test",
                    OffersTakeout = true,
                    PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                    Tags = new List<string>
                    {
                        "pizza",
                        "halal"
                    },
                    Email = "test@g22.com",
                    Website = "",
                    FoodBusinessAdministratorId = fastFood.FoodBusinessAdministratorId,
                    FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                    OpeningTime = "08:00",
                    ClosingTime = "18:00",
                    NearbyLocationDescription = "inferieur a 20km",
                    FarLocationDescription = "superieur a 20km",
                    FarLocationPrice = 500,
                    NearbyLocationPrice = 200,
                };

                await SendAsync(updateFoodBusinessCommand);

                var list = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);

                list.FoodBusinessId.Should().Be(updateFoodBusinessCommand.Id);
                list.Name.Should().Be("Taj mahal Updated test");
                list.AcceptDelivery.Should().BeTrue();
                list.OpeningTime.Should().Be(updateFoodBusinessCommand.OpeningTime);
                list.ClosingTime.Should().Be(updateFoodBusinessCommand.ClosingTime);
                list.NearbyLocationDescription.Should().Be(updateFoodBusinessCommand.NearbyLocationDescription);
                list.NearbyLocationPrice.Should().Be(updateFoodBusinessCommand.NearbyLocationPrice);
                list.FarLocationDescription.Should().Be(updateFoodBusinessCommand.FarLocationDescription);
                list.FarLocationPrice.Should().Be(updateFoodBusinessCommand.FarLocationPrice);
            });
        }
    }
}