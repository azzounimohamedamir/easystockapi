using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Sections.Commands
{
    using static Testing;

    [TestFixture]
    public class RemoveDishFromSectionTest : TestBase
    {
        [Test]
        public async Task RemoveDishFromSection_ShouldRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var createDishCommand = await CreateDish(fastFood);

            var addDishToSectionCommand = await AddDishToSection(createSectionCommand, createDishCommand);
            var item = Where<SectionDish>(x =>
            x.DishId == Guid.Parse(addDishToSectionCommand.DishId) &&
            x.SectionId == Guid.Parse(addDishToSectionCommand.SectionId));
            item.Should().NotBeNull();
            item.Should().HaveCount(1);

            var removeDishFromSectionCommand = new RemoveDishFromSectionCommand
            {
                SectionId = item[0].SectionId.ToString(),
                DishId = item[0].DishId.ToString(),
            };
            await SendAsync(removeDishFromSectionCommand);
            var deletedItem = Where<SectionDish>(x =>
                x.DishId == Guid.Parse(addDishToSectionCommand.DishId) &&
                 x.SectionId == Guid.Parse(addDishToSectionCommand.SectionId));
            deletedItem.Should().HaveCount(0);
        }

        private static async Task<AddDishToSectionCommand> AddDishToSection(CreateSectionCommand createSectionCommand, Application.Dishes.Commands.CreateDishCommand createDishCommand)
        {
            var addDishToSectionCommand = new AddDishToSectionCommand
            {
                SectionId = createSectionCommand.Id.ToString(),
                DishId = createDishCommand.Id.ToString(),
            };
            await SendAsync(addDishToSectionCommand);
            return addDishToSectionCommand;
        }

        private static async Task<Application.Dishes.Commands.CreateDishCommand> CreateDish(Domain.Entities.FoodBusiness fastFood)
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            return createDishCommand;
        }

        private static async Task<CreateProductOnStockCommand> CreateMenu(Domain.Entities.FoodBusiness fastFood)
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