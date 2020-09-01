using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task CreateFoodBusiness_ShouldSaveToDB()
        {
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
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
                Name = "Taj mahal",
                OffersTakeout = true,
                PhoneNumber = new Common.Dtos.ValueObjects.PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Tags = "",
                Website = "",
                FoodBusinessAdministratorId = "4",
                FoodBusinessCategory = FoodBusinessCategory.Restaurant

            };
            var validationResult = await SendAsync(createFoodBusinessCommand);

            var item = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(createFoodBusinessCommand.CmdId);
            item.Name.Should().BeEquivalentTo(createFoodBusinessCommand.Name);
            item.Address.Should().BeEquivalentTo(createFoodBusinessCommand.Address);
        }
    }
}
