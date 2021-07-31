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
            var foodBusinessId = Guid.NewGuid();
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                Id = foodBusinessId,
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand).ConfigureAwait(false);
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateMenuCommand
                {
                    Name = "tacos Dz  " + i,
                    MenuState = (int) MenuState.Enabled,
                    FoodBusinessId = foodBusinessId
                }).ConfigureAwait(false);
            var query = new GetMenusListQuery {FoodBusinessId = foodBusinessId, Page = 1, PageSize = 5};
            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}