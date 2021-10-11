using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusinessClient.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Queries
{
    using static Testing;

    public class GetFoodBusinessClientByManagerIdTests : TestBase
    {
        [Test]
        public async Task ShouldGetFoodBusinessClient_ByManagerId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var fastFood = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);
            var query = new GetFoodBusinessClientByManagerIdQuery
            {
                FoodBusinessClientManagerId = fastFood.ManagerId
            };
            var result = await SendAsync(query);
            result.Name.Should().Be("G22 REI");
        }
    }
}
