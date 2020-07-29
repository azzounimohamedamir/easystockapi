using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;
    public class GetFoodBusinessByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnRestaurant()
        {
            var restaurantId = Guid.NewGuid(); 
            await SendAsync(new CreateFoodBusinessCommand
            {
                NameEnglish = "TobeGotByID For Test",
                AverageRating = 12,
                HasCarParking = true,
                CmdId = restaurantId
            });

            var query = new GetFoodBusinessByIdQuery
            {
                FoodBusinessId = restaurantId
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }
    }
}
