using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.SubSections.Queries;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Application.Sections.Commands;

namespace SmartRestaurant.Application.IntegrationTests.SubSections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetSubSectionMenuItemsTest : TestBase
    {
        [Test]
        public async Task ShouldGetSubSectionMenuItems_BySubSectionId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand);

            var createDishCommand = await CreateDish(fastFood);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);

            await AddDishToSubSection(createSubSectionCommand, createDishCommand);
            await AddProductToSubSection(createSubSectionCommand, createProductCommand);
            
           
            var result_01 = await SendAsync(new GetSubSectionMenuItemsQuery { SubSectionId = createSubSectionCommand.Id.ToString() });
            result_01.Data.Should().HaveCount(2);

            var result_02 = await SendAsync(new GetSubSectionMenuItemsQuery { SubSectionId = createSubSectionCommand.Id.ToString(), SearchKey = "Fakhitasse" });
            result_02.Data.Should().HaveCount(1);

            var result_03 = await SendAsync(new GetSubSectionMenuItemsQuery { SubSectionId = createSubSectionCommand.Id.ToString(), SearchKey = "hamoud 2L" });
            result_03.Data.Should().HaveCount(1);

            var result_04 = await SendAsync(new GetSubSectionMenuItemsQuery { SubSectionId = createSubSectionCommand.Id.ToString(), SearchKey = "test" });
            result_04.Data.Should().HaveCount(0);
        }

        private static async Task<AddProductToSubSectionCommand> AddProductToSubSection(CreateSubSectionCommand createSubSectionCommand, Application.Products.Commands.CreateProductCommand createProductCommand)
        {
            var addProductToSubSectionCommand = new AddProductToSubSectionCommand
            {
                SubSectionId = createSubSectionCommand.Id.ToString(),
                ProductId = createProductCommand.Id.ToString(),
            };
            await SendAsync(addProductToSubSectionCommand);
            return addProductToSubSectionCommand;
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

        private static async Task<Application.Dishes.Commands.CreateDishCommand> CreateDish(Domain.Entities.FoodBusiness fastFood)
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            return createDishCommand;
        }

        private static async Task<CreateMenuCommand> CreateMenu(Domain.Entities.FoodBusiness fastFood)
        {
            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            return createMenuCommand;
        }
    }
}