using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants
{
    using static Testing;
    [TestFixture]
    public class CreateRestaurantTests : TestBase
    {
        [Test]
        public async Task CreateRestaurant_SouldSaveDB()
        {
            CreateRestaurantCommand createRestaurantCommand = new CreateRestaurantCommand
            {
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new Common.Dtos.ValueObjects.AddressDto()
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
                IsHandicapFreindly = true,
                NameArabic = "تاج محل",
                NameEnglish = "Taj mahal",
                NameFrench = "Taj mahal",
                OffersTakeout = true,
                PhoneNumber = new Common.Dtos.ValueObjects.PhoneNumberDto() { CountryCode = 213, Number = 670217536 },
                Tags = "",
                Website = ""

            };
            var itemId = await SendAsync<Guid>(createRestaurantCommand);


            var item = await FindAsync<Restaurant>(itemId);

            item.Should().NotBeNull();
            item.RestaurantId.Should().Be(itemId);
            item.NameArabic.Should().BeEquivalentTo(createRestaurantCommand.NameArabic);
            item.NameEnglish.Should().BeEquivalentTo(createRestaurantCommand.NameEnglish);
            item.NameFrench.Should().BeEquivalentTo(createRestaurantCommand.NameFrench);
            item.Address.Should().BeEquivalentTo(createRestaurantCommand.Address);
        }
    }
}
