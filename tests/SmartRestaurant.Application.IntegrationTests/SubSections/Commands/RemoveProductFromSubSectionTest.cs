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
    public class RemoveProductFromSubSectionTest : TestBase
    {
        [Test]
        public async Task RemoveProductFromSubSection_ShouldRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await CreateMenu(fastFood);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand);
            var createProductCommand = await ProductTestTools.CreateProduct();

            var addProductToSubSectionCommand = await AddProductToSubSection(createSubSectionCommand, createProductCommand);
            var item = Where<SubSectionProduct>(x =>
            x.ProductId == Guid.Parse(addProductToSubSectionCommand.ProductId) &&
            x.SubSectionId == Guid.Parse(addProductToSubSectionCommand.SubSectionId));
            item.Should().NotBeNull();
            item.Should().HaveCount(1);

            var removeProductFromSubSectionCommand = new RemoveProductFromSubSectionCommand
            {
                SubSectionId = item[0].SubSectionId.ToString(),
                ProductId = item[0].ProductId.ToString(),
            };
            await SendAsync(removeProductFromSubSectionCommand);
            var deletedItem = Where<SubSectionProduct>(x =>
                x.ProductId == Guid.Parse(addProductToSubSectionCommand.ProductId) &&
                x.SubSectionId == Guid.Parse(addProductToSubSectionCommand.SubSectionId));
            deletedItem.Should().HaveCount(0);
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