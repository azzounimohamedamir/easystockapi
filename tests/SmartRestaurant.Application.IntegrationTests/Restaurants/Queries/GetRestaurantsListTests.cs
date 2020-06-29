using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Queries;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants
{
    using static Testing;
    public class GetRestaurantsListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllRestaurantList()
        {
            for (int i = 0; i < 5; i++)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.UpdateRestaurantInfo("تاكوس دزاد", "tacos Dz" + i.ToString() + "", "tacos Dz" + i.ToString() + "", "Tasty Tacos", true, true, true, true, "#Tacos", "wwww.wwww.wwww", 12, 3);
                await AddAsync(restaurant);
            }
            var query = new GetRestaurantsListQuery();

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}
