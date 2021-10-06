using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Products.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateProductTest : TestBase
    {    
        [Test]
        public async Task CreateProductWithSectionAsParent_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);


            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Name = "section test menu"
            };
            await SendAsync(createSectionCommand);

            var createProductCommand = await ProductTestTools.CreateProduct(createSectionCommand.Id, (int)ProductParent.Section);
            var createdProduct = await FindAsync<Product>(createProductCommand.Id);
            createdProduct.Should().NotBeNull();
            createdProduct.ProductId.Should().Be(createProductCommand.Id);
            createdProduct.Name.Should().BeEquivalentTo(createProductCommand.Name);
            createdProduct.Description.Should().Be(createProductCommand.Description);
            createdProduct.Price.Should().Be(150);
            createdProduct.EnergeticValue.Should().Be(200);
            createdProduct.SectionId.Should().Be(createSectionCommand.Id);
            createdProduct.SubSectionId.Should().Be(null);
            createdProduct.CreatedBy.Should().Be(_authenticatedUserId);
            createdProduct.CreatedAt.Should().NotBe(default);
            createdProduct.LastModifiedBy.Should().BeNull();
            createdProduct.LastModifiedAt.Should().Be(default);
        }

        [Test]
        public async Task CreateProductWithSubSectionAsParent_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);


            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Name = "section test menu"
            };
            await SendAsync(createSectionCommand);

            var createSubSectionCommand = new CreateSubSectionCommand
            {
                SectionId = createSectionCommand.Id,
                Name = "sub-section test menu"
            };
            await SendAsync(createSubSectionCommand);


            var createProductCommand = await ProductTestTools.CreateProduct(createSubSectionCommand.Id, (int)ProductParent.SubSection);
            var createdProduct = await FindAsync<Product>(createProductCommand.Id);
            createdProduct.Should().NotBeNull();
            createdProduct.ProductId.Should().Be(createProductCommand.Id);
            createdProduct.Name.Should().BeEquivalentTo(createProductCommand.Name);
            createdProduct.Description.Should().Be(createProductCommand.Description);
            createdProduct.Price.Should().Be(150);
            createdProduct.EnergeticValue.Should().Be(200);
            createdProduct.SectionId.Should().Be(null);
            createdProduct.SubSectionId.Should().Be(createSubSectionCommand.Id);
            createdProduct.CreatedBy.Should().Be(_authenticatedUserId);
            createdProduct.CreatedAt.Should().NotBe(default);
            createdProduct.LastModifiedBy.Should().BeNull();
            createdProduct.LastModifiedAt.Should().Be(default);
        }
    }
}
