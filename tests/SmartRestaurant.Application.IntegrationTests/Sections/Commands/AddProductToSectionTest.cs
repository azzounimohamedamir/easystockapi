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
    public class AddProductToSectionTest : TestBase
    {
        [Test]
        public async Task AddProductToSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await createMenu(fastFood);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);

            var addProductToSectionCommand = new AddProductToSectionCommand
            {
                SectionId = createSectionCommand.Id.ToString(),
                ProductId = createProductCommand.Id.ToString(),
            };
            await SendAsync(addProductToSectionCommand);
            var item = Where<SectionProduct>(x =>
            x.ProductId == Guid.Parse(addProductToSectionCommand.ProductId) &&
            x.SectionId == Guid.Parse(addProductToSectionCommand.SectionId));

            item.Should().NotBeNull();
            item.Should().HaveCount(1);
            item[0].SectionId.Should().Be(addProductToSectionCommand.SectionId);
            item[0].ProductId.Should().Be(addProductToSectionCommand.ProductId);
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