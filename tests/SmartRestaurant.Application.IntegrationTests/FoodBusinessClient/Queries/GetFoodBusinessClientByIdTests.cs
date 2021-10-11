using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using SmartRestaurant.Application.FoodBusinessClient.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Queries
{
    using static Testing;

    class GetFoodBusinessClientByIdTests : TestBase
    {
        [Test]
        public async Task ShouldGetFoodBusinessClient_ById()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var fastFood = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);
            var query = new GetFoodBusinessClientByIdQuery
            {
                FoodBusinessClientId = fastFood.FoodBusinessClientId.ToString()
            };
            var result = await SendAsync(query);
            result.Name.Should().Be("G22 REI");
        }
    }
}
