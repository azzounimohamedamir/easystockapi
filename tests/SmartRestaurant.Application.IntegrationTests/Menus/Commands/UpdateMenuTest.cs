﻿using System.Threading.Tasks;
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
    public class UpdateMenuTest : TestBase
    {
        [Test]
        public async Task UpdateMenu_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
         
            var createMenuCommand = new CreateProductOnStockCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            await SendAsync(new UpdateProductOnStockCommand
            {
                Id = createMenuCommand.Id,
                Name = "test menu2",
                MenuState = MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            });

            var item = await FindAsync<Menu>(createMenuCommand.Id);

            item.Should().NotBeNull();
            item.MenuState.Should().Be(MenuState.Enabled);
            item.Name.Should().Be("test menu2");
        }
    }
}