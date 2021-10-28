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
    public class AddProductToSubSectionTest : TestBase
    {
        [Test]
        public async Task AddProductToSubSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createMenuCommand = await createMenu(fastFood);
            var createSectionCommand = await createSection(createMenuCommand);
            var createSubSectionCommand = await createSubSection(createSectionCommand);
            var createProductCommand = await ProductTestTools.CreateProduct();

            var addProductToSubSectionCommand = new AddProductToSubSectionCommand
            {
                SubSectionId = createSubSectionCommand.Id.ToString(),
                ProductId = createProductCommand.Id.ToString(),
            };
            await SendAsync(addProductToSubSectionCommand);
            var item = Where<SubSectionProduct>(x =>
            x.ProductId == Guid.Parse(addProductToSubSectionCommand.ProductId) &&
            x.SubSectionId == Guid.Parse(addProductToSubSectionCommand.SubSectionId));

            item.Should().NotBeNull();
            item.Should().HaveCount(1);
            item[0].SubSectionId.Should().Be(addProductToSubSectionCommand.SubSectionId);
            item[0].ProductId.Should().Be(addProductToSubSectionCommand.ProductId);
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