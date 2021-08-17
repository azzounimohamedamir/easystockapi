using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Menus.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Menus.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllMenusQueryTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllMenus_ByFoodBusinessId()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateMenuCommand
                {
                    Name = "tacos Dz  " + i,
                    MenuState = (int) MenuState.Enabled,
                    FoodBusinessId = createFoodBusinessCommand.Id
                });
            var query = new GetMenusListQuery
                {FoodBusinessId = createFoodBusinessCommand.Id, Page = 1, PageSize = 5};
            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}