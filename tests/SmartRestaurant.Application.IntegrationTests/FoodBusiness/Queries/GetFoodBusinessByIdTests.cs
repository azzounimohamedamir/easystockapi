using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;
    public class GetFoodBusinessByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnFoodBusiness()
        {
            var foodBusinessId = Guid.NewGuid();
            await SendAsync(new CreateFoodBusinessCommand
            {
                Name = "TobeGotByID For Test",
                AverageRating = 12,
                HasCarParking = true,
                CmdId = foodBusinessId,
                FoodBusinessAdministratorId = Guid.NewGuid().ToString()
            });

            var query = new GetFoodBusinessByIdQuery
            {
                FoodBusinessId = foodBusinessId
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
        }
    }
}
