using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusinessClient.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Queries
{
    using static Testing;

    public class GetFoodBusinessClientListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessClientList()
        {
            await RolesTestTools.CreateRoles();
            for (var i = 0; i < 5; i++)
            {
                var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
                var fastFood = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id, "tacos Dz  " + i);
            }

            var query = new GetFoodBusinesClientListQuery { Page = 1, PageSize = 5 };

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}
