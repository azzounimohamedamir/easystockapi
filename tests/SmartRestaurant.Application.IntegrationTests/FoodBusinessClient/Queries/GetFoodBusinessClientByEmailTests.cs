using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusinessClient.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Queries
{
    using static Testing;

    public class GetFoodBusinessClientByEmailTests : TestBase
    {
        [Test]
        public async Task ShouldGetFoodBusinessClient_ByEmail()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var FoodBusinessClient = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);
            var query = new GetFoodBusinessClientByEmailQuery
            {
                Email = FoodBusinessClient.Email
            };
            var result = await SendAsync(query);
            result.Name.Should().Be("G22 REI");
        }
    }
}
