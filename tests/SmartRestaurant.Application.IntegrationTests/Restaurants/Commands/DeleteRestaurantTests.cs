using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants.Commands
{
    using static Testing;
    [TestFixture]
    public class DeleteRestaurantTests : TestBase
    {
        [Test]
        public async Task DeleteRestaurant_ShouldSaveToDB()
        {
            var RestaurantId = await SendAsync(new CreateRestaurantCommand
            {
                NameEnglish = "Taj mahal"
            });


            await SendAsync(new DeleteRestaurantCommand
            {
                RestaurantId = RestaurantId
            });

            var RestaurantIdFound = await FindAsync<Restaurant>(RestaurantId);

            RestaurantIdFound.Should().BeNull();
        }
    }
}
