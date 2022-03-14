using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessClient.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteFoodBusinessClientTests : TestBase
    {
        [Test]
        public async Task DeleteFoodBusinessClientTask()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessClientManager = await UsersTestTools.CreateFoodBusinessClientManager();
            var foodBusinessClient = await FoodBusinessClientTestTools.CreateFoodBusinessClient(foodBusinessClientManager.Id);


            await SendAsync(new DeleteFoodBusinessClientCommand
            {
                Id = foodBusinessClient.FoodBusinessClientId.ToString()
            });

            var item = await FindAsync<Domain.Entities.FoodBusinessClient>(foodBusinessClient.FoodBusinessClientId);
            item.Should().BeNull();
        }
    }
}
