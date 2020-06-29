using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
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
                var RestaurantId = await SendAsync(new CreateRestaurantCommand
                {
                    NameFrench = "tacos Dz  " + i.ToString(),
                    NameEnglish = "tacos Dz  " + i.ToString(),
                    NameArabic = "تاكوس دزاد" + i.ToString(),

                    AverageRating = 12,
                    HasCarParking = true
                });
            }
            var query = new GetRestaurantsListQuery();

            var result = await SendAsync(query);

            result.Should().HaveCount(5);
        }
    }
}
