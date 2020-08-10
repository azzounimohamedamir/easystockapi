using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
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
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                NameEnglish = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var cmdId = Guid.NewGuid();
            var validationResult = await SendAsync(new CreateMenuCommand
            {
                CmdId = cmdId,
                Name = "test menu",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.CmdId
            });
            var item = await FindAsync<Menu>(cmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.MenuState.Should().Be(MenuState.Enabled);
            item.Name.Should().Be("test menu");
        }
        [Test]
        public async Task CreateMenuWitheEnabledState_ShouldDisableOtherMenus()
        {
            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                NameEnglish = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
           
             await SendAsync(new CreateMenuCommand
            {
                Name = "test menu1",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.CmdId
            });
             await SendAsync(new CreateMenuCommand
            {
                Name = "test menu2",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.CmdId
            });
            var items =  Where<Menu>(menu => menu.MenuState == MenuState.Enabled && menu.FoodBusinessId == createFoodBusinessCommand.CmdId);

            items.Count.Should().Be(1);

        }
    }
}
