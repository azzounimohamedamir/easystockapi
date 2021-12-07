using System;
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
    public class GetActiveMenuTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllMenus_ByFoodBusinessId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 5; i++)
            {
                await SendAsync(new CreateMenuCommand
                {
                    Name = "tacos Dz  " + i,
                    FoodBusinessId = fastFood.FoodBusinessId
                });
            }

            var menuId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                Id = menuId,
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            });
            await SendAsync(new UpdateMenuCommand
            {
                Id = menuId,
                Name = "test menu -- enabled",
                MenuState = MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            });

            var result = await SendAsync(new GetActiveMenuQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            result.MenuId.Should().Be(menuId);
            result.Name.Should().Be("test menu -- enabled");
        }
    }
}