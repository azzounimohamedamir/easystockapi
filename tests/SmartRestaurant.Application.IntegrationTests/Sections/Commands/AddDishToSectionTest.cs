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
    public class AddDishToSectionTest : TestBase
    {
        [Test]
        public async Task AddDishToSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await createMenu(fastFood);
            var createSectionCommand = await createSection(createMenuCommand);
            var createDishCommand = await createDish(fastFood);

            var addDishToSectionCommand = new AddDishToSectionCommand
            {
                SectionId = createSectionCommand.Id.ToString(),
                DishId = createDishCommand.Id.ToString(),
            };
            await SendAsync(addDishToSectionCommand);
            var item = Where<SectionDish>(x => 
            x.DishId == Guid.Parse(addDishToSectionCommand.DishId) && 
            x.SectionId == Guid.Parse(addDishToSectionCommand.SectionId));

            item.Should().NotBeNull();
            item.Should().HaveCount(1);
            item[0].SectionId.Should().Be(addDishToSectionCommand.SectionId);
            item[0].DishId.Should().Be(addDishToSectionCommand.DishId);
        }

        private static async Task<Application.Dishes.Commands.CreateDishCommand> createDish(Domain.Entities.FoodBusiness fastFood)
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            return createDishCommand;
        }

        private static async Task<CreateSectionCommand> createSection(CreateMenuCommand createMenuCommand)
        {
            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Name = "section test menu"
            };
            await SendAsync(createSectionCommand);
            return createSectionCommand;
        }

        private static async Task<CreateMenuCommand> createMenu(Domain.Entities.FoodBusiness fastFood)
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