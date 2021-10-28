using System;
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
    public class RemoveDishFromSubSectionTest : TestBase
    {
        [Test]
        public async Task RemoveDishFromSubSection_ShouldRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await CreateSection(createMenuCommand);
            var createSubSectionCommand = await createSubSection(createSectionCommand);
            var createDishCommand = await CreateDish(fastFood);

            var addDishToSubSectionCommand = await AddDishToSubSection(createSubSectionCommand, createDishCommand);
            var item = Where<SubSectionDish>(x =>
            x.DishId == Guid.Parse(addDishToSubSectionCommand.DishId) &&
            x.SubSectionId == Guid.Parse(addDishToSubSectionCommand.SubSectionId));
            item.Should().NotBeNull();
            item.Should().HaveCount(1);

            var removeDishFromSubSectionCommand = new RemoveDishFromSubSectionCommand
            {
                SubSectionId = item[0].SubSectionId.ToString(),
                DishId = item[0].DishId.ToString(),
            };
            await SendAsync(removeDishFromSubSectionCommand);
            var deletedItem = Where<SubSectionDish>(x =>
                x.DishId == Guid.Parse(addDishToSubSectionCommand.DishId) &&
                x.SubSectionId == Guid.Parse(addDishToSubSectionCommand.SubSectionId));
            deletedItem.Should().HaveCount(0);
        }

        private static async Task<AddDishToSubSectionCommand> AddDishToSubSection(CreateSubSectionCommand createSubSectionCommand, Application.Dishes.Commands.CreateDishCommand createDishCommand)
        {
            var addDishToSubSectionCommand = new AddDishToSubSectionCommand
            {
                SubSectionId = createSubSectionCommand.Id.ToString(),
                DishId = createDishCommand.Id.ToString(),
            };
            await SendAsync(addDishToSubSectionCommand);
            return addDishToSubSectionCommand;
        }

        private static async Task<CreateSubSectionCommand> createSubSection(CreateSectionCommand createSectionCommand)
        {
            var createSubSectionCommand = new CreateSubSectionCommand
            {
                SectionId = createSectionCommand.Id,
                Name = "sub section test menu"
            };
            await SendAsync(createSubSectionCommand);
            return createSubSectionCommand;
        }

        private static async Task<Application.Dishes.Commands.CreateDishCommand> CreateDish(Domain.Entities.FoodBusiness fastFood)
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            return createDishCommand;
        }

        private static async Task<CreateSectionCommand> CreateSection(CreateMenuCommand createMenuCommand)
        {
            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Name = "section test menu"
            };
            await SendAsync(createSectionCommand);
            return createSectionCommand;
        }

        private static async Task<CreateMenuCommand> CreateMenu(Domain.Entities.FoodBusiness fastFood)
        {
            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            return createMenuCommand;
        }
    }
}