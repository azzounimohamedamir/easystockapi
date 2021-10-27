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
    public class RemoveProductFromSectionTest : TestBase
    {
        [Test]
        public async Task RemoveProductFromSection_ShouldRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await CreateSection(createMenuCommand);
            var createProductCommand = await ProductTestTools.CreateProduct();
            var addProductToSectionCommand = await AddProductToSection(createSectionCommand, createProductCommand);
            var item = Where<SectionProduct>(x =>
            x.ProductId == Guid.Parse(addProductToSectionCommand.ProductId) &&
            x.SectionId == Guid.Parse(addProductToSectionCommand.SectionId));
            item.Should().NotBeNull();
            item.Should().HaveCount(1);

            var removeProductFromSectionCommand = new RemoveProductFromSectionCommand
            {
                SectionId = item[0].SectionId.ToString(),
                ProductId = item[0].ProductId.ToString(),
            };
            await SendAsync(removeProductFromSectionCommand);
            item.Should().NotBeNull();
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