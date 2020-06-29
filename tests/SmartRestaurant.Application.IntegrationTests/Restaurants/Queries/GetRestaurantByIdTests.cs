using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Queries;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants.Queries
{
    using static Testing;
    public class GetRestaurantByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnRestaurant()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.UpdateRestaurantInfo("تاكوس دزاد", "tacos Dz", "tacos Dz", "Tasty Tacos", true, true, true, true, "#Tacos", "wwww.wwww.wwww", 12, 3);
            await AddAsync(restaurant);

            var query = new GetRestaurantByIdQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }
    }
}
