using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;
    public class UpdateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateRestaurant()
        {
            var restaurantId = Guid.NewGuid();
            await SendAsync(new CreateFoodBusinessCommand
            {
                NameEnglish = "Taj mahal",
                AverageRating = 12,
                HasCarParking = true,
                CmdId = restaurantId
            });

            var command = new UpdateFoodBusinessCommand
            {
                CmdId = restaurantId,
                NameEnglish = "Taj mahal Updated test"

            };

            await SendAsync(command);

            var list = await FindAsync<Domain.Entities.FoodBusiness>(restaurantId);

            list.NameEnglish.Should().Be(command.NameEnglish);
        }
    }
}
