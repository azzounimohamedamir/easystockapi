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
    public class DeleteMenuTest : TestBase
    {
        [Test]
        public async Task DeleteMenu_ShouldSaveToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu1",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            };
            await SendAsync(createMenuCommand);
            await SendAsync(new DeleteMenuCommand {Id = createMenuCommand.Id});
            var item = await FindAsync<Menu>(createMenuCommand.Id);
            item.Should().BeNull();
        }
    }
}