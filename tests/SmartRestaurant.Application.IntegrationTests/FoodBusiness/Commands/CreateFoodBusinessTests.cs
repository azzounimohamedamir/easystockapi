using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task CreateRestaurant_ShouldSaveToDB()
        {
            CreateFoodBusinessCommand createRestaurantCommand = new CreateFoodBusinessCommand
            {
                
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new Common.Dtos.ValueObjects.AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new Common.Dtos.ValueObjects.GeoPositionDto()
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                AverageRating = 4,
                Description = "",
                HasCarParking = true,
                IsHandicapFriendly = true,
                NameArabic = "تاج محل",
                NameEnglish = "Taj mahal",
                NameFrench = "Taj mahal",
                OffersTakeout = true,
                PhoneNumber = new Common.Dtos.ValueObjects.PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Tags = "",
                Website = "",
                FoodBusinessAdministratorId = "4",
                FoodBusinessCategory = FoodBusinessCategory.Restaurant

            };
            var validationResult = await SendAsync(createRestaurantCommand);

            var item = await FindAsync<Domain.Entities.FoodBusiness>(createRestaurantCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(createRestaurantCommand.CmdId);
            item.NameArabic.Should().BeEquivalentTo(createRestaurantCommand.NameArabic);
            item.NameEnglish.Should().BeEquivalentTo(createRestaurantCommand.NameEnglish);
            item.NameFrench.Should().BeEquivalentTo(createRestaurantCommand.NameFrench);
            item.Address.Should().BeEquivalentTo(createRestaurantCommand.Address);
        }
    }
}
