using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Sections.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Sections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetSectionMenuItemsTest : TestBase
    {
        [Test]
        public async Task ShouldGetSectionMenuItems_BySectionId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await CreateSection(createMenuCommand);
            var createDishCommand = await CreateDish(fastFood);
            var createProductCommand = await ProductTestTools.CreateProduct();

            await AddDishToSection(createSectionCommand, createDishCommand);
            await AddProductToSection(createSectionCommand, createProductCommand);
            
           
            var result_01 = await SendAsync(new GetSectionMenuItemsQuery { SectionId = createSectionCommand.Id.ToString() });
            result_01.Data.Should().HaveCount(2);

            var result_02 = await SendAsync(new GetSectionMenuItemsQuery { SectionId = createSectionCommand.Id.ToString(), SearchKey = "Fakhitasse" });
            result_02.Data.Should().HaveCount(1);

            var result_03 = await SendAsync(new GetSectionMenuItemsQuery { SectionId = createSectionCommand.Id.ToString(), SearchKey = "hamoud 2L" });
            result_03.Data.Should().HaveCount(1);

            var result_04 = await SendAsync(new GetSectionMenuItemsQuery { SectionId = createSectionCommand.Id.ToString(), SearchKey = "test" });
            result_04.Data.Should().HaveCount(0);
        }

        private static async Task<AddProductToSectionCommand> AddProductToSection(CreateSectionCommand createSectionCommand, Application.Products.Commands.CreateProductCommand createProductCommand)
        {
            var addProductToSectionCommand = new AddProductToSectionCommand
            {
                SectionId = createSectionCommand.Id.ToString(),
                ProductId = createProductCommand.Id.ToString(),
            };
            await SendAsync(addProductToSectionCommand);
            return addProductToSectionCommand;
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