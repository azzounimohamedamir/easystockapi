using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;

    public class GetFoodBusinessListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessList()
        {
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateFoodBusinessCommand
                {
                    Name = "tacos Dz  " + i,
                    FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                    AverageRating = 12,
                    HasCarParking = true
                });
            var query = new GetFoodBusinessListQuery {Page = 1, PageSize = 5};

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}