using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Menus.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateMenuTest : TestBase
    {
        [Test]
        public async Task CreateMenu_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            var item = await FindAsync<Menu>(createMenuCommand.Id);

            item.Should().NotBeNull();
            item.MenuState.Should().Be(MenuState.Enabled);
            item.Name.Should().Be("test menu");
        }

        [Test]
        public async Task CreateMenuWitheEnabledState_ShouldDisableOtherMenus()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            await SendAsync(new CreateMenuCommand
            {
                Name = "test menu1",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            });
            await SendAsync(new CreateMenuCommand
            {
                Name = "test menu2",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            });
            var items = Where<Menu>(menu =>
                menu.MenuState == MenuState.Enabled && menu.FoodBusinessId == fastFood.FoodBusinessId);

            items.Count.Should().Be(1);
        }
    }
}