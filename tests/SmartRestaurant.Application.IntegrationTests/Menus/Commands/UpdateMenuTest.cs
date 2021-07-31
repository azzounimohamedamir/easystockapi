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
            var cmdId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                Id = cmdId,
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            });
            var validationResult = await SendAsync(new UpdateMenuCommand
            {
                Id = cmdId,
                Name = "test menu2",
                MenuState = (int) MenuState.Disabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            });

            var item = await FindAsync<Menu>(cmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.MenuState.Should().Be(MenuState.Disabled);
            item.Name.Should().Be("test menu2");
        }
    }
}