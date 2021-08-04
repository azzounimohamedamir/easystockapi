using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Menus.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateMenuTest
    {
        [Test]
        public async Task CreateMenu_ShouldSaveToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            };
            await SendAsync(createMenuCommand);
            await SendAsync(new UpdateMenuCommand
            {
                Id = createMenuCommand.Id,
                Name = "test menu2",
                MenuState = (int) MenuState.Disabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            });

            var item = await FindAsync<Menu>(createMenuCommand.Id);

            item.Should().NotBeNull();
            item.MenuState.Should().Be(MenuState.Disabled);
            item.Name.Should().Be("test menu2");
        }
    }
}