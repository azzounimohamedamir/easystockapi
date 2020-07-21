using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Application.Restaurants.Queries;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants.Queries
{
    using static Testing;
    public class GetRestaurantByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnRestaurant()
        {

            var RestaurantId = await SendAsync(new CreateRestaurantCommand
            {
                NameEnglish = "TobeGotByID For Test",
                AverageRating = 12,
                HasCarParking = true
            });

            var query = new GetRestaurantByIdQuery
            {
                RestaurantId = RestaurantId
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }
    }
}
