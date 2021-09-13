using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
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
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateMenuCommand
                {
                    Name = "tacos Dz  " + i,
                    MenuState = (int) MenuState.Enabled,
                    FoodBusinessId = fastFood.FoodBusinessId
                });
            var query = new GetMenusListQuery
                {FoodBusinessId = fastFood.FoodBusinessId, Page = 1, PageSize = 5};
            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}