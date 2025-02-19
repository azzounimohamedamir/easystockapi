﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.SubSections.Commands
{
    using static Testing;

    [TestFixture]
    public class AddDishToSubSectionTest : TestBase
    {
        [Test]
        public async Task AddDishToSubSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await createMenu(fastFood);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand, "sub section test menu");
            var createDishCommand = await createDish(fastFood);


            var addDishToSubSectionCommand = new AddDishToSubSectionCommand
            {
                SubSectionId = createSubSectionCommand.Id.ToString(),
                DishId = createDishCommand.Id.ToString(),
            };
            await SendAsync(addDishToSubSectionCommand);
            var item = Where<SubSectionDish>(x => 
            x.DishId == Guid.Parse(addDishToSubSectionCommand.DishId) && 
            x.SubSectionId == Guid.Parse(addDishToSubSectionCommand.SubSectionId));

            item.Should().NotBeNull();
            item.Should().HaveCount(1);
            item[0].SubSectionId.Should().Be(addDishToSubSectionCommand.SubSectionId);
            item[0].DishId.Should().Be(addDishToSubSectionCommand.DishId);
        }

        private static async Task<Application.Dishes.Commands.CreateDishCommand> createDish(Domain.Entities.FoodBusiness fastFood)
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            return createDishCommand;
        }

        private static async Task<CreateProductOnStockCommand> createMenu(Domain.Entities.FoodBusiness fastFood)
        {
            var createMenuCommand = new CreateProductOnStockCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            return createMenuCommand;
        }
    }
}