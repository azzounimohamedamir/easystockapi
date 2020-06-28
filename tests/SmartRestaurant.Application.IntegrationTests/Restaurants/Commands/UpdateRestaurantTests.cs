using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants.Commands
{
    using static Testing;
    public class UpdateRestaurantTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateRestaurant()
        {

            var RestaurantId = await SendAsync(new CreateRestaurantCommand
            {
                NameEnglish = "Taj mahal"
            });

            var command = new UpdateRestaurantCommand
            {
                RestaurantId = RestaurantId,
                NameEnglish = "Taj mahal Updated test"
            };

            await SendAsync(command);

            var list = await FindAsync<Restaurant>(RestaurantId);

            list.NameEnglish.Should().Be(command.NameEnglish);
        }
    }
}
