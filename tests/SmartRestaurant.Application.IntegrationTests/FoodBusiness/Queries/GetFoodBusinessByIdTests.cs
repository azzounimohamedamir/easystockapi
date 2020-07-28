using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Restaurants.Queries;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;
    public class GetFoodBusinessByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnRestaurant()
        {
            var restaurantId = Guid.NewGuid(); 
            await SendAsync(new CreateFoodBusinnessCommand
            {
                NameEnglish = "TobeGotByID For Test",
                AverageRating = 12,
                HasCarParking = true,
                CmdId = restaurantId
            });

            var query = new GetFoodBusinessByIdQuery
            {
                RestaurantId = restaurantId
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }
    }
}
