using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Products.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateProductTest : TestBase
    {   
        [Test]
        public async Task UpdateProductWithSectionAsParent_ShouldSaveToDB()
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

            var product = await ProductTestTools.CreateProduct(createSectionCommand.Id, (int)ProductParent.Section);

            var updateProductCommand = await UpdateProduct(product);
            var updatedProduct = await FindAsync<Product>(Guid.Parse(updateProductCommand.Id));

            updatedProduct.Should().NotBeNull();
            updatedProduct.ProductId.Should().Be(product.Id);
            updatedProduct.Name.Should().BeEquivalentTo(updateProductCommand.Name);
            updatedProduct.Description.Should().Be(updateProductCommand.Description);
            updatedProduct.Price.Should().Be(updateProductCommand.Price);
            updatedProduct.EnergeticValue.Should().Be(updateProductCommand.EnergeticValue);
            updatedProduct.SectionId.Should().Be(product.SectionId);
            updatedProduct.SubSectionId.Should().Be(null);
            updatedProduct.CreatedBy.Should().NotBeNull();
            updatedProduct.CreatedAt.Should().NotBe(default);
            updatedProduct.LastModifiedBy.Should().Be(_authenticatedUserId);
            updatedProduct.LastModifiedAt.Should().NotBe(default);
        }
     
        [Test]
        public async Task UpdateProductWithSubSectionAsParent_ShouldSaveToDB()
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

            var product = await ProductTestTools.CreateProduct(createSubSectionCommand.Id, (int)ProductParent.SubSection);

            var updateProductCommand = await UpdateProduct(product);
            var updatedProduct = await FindAsync<Product>(Guid.Parse(updateProductCommand.Id));
            updatedProduct.Should().NotBeNull();
            updatedProduct.ProductId.Should().Be(product.Id);
            updatedProduct.Name.Should().BeEquivalentTo(updateProductCommand.Name);
            updatedProduct.Description.Should().Be(updateProductCommand.Description);
            updatedProduct.Price.Should().Be(updateProductCommand.Price);
            updatedProduct.EnergeticValue.Should().Be(updateProductCommand.EnergeticValue);
            updatedProduct.SectionId.Should().Be(null);
            updatedProduct.SubSectionId.Should().Be(product.SubSectionId);
            updatedProduct.CreatedBy.Should().NotBeNull();
            updatedProduct.CreatedAt.Should().NotBe(default);
            updatedProduct.LastModifiedBy.Should().Be(_authenticatedUserId);
            updatedProduct.LastModifiedAt.Should().NotBe(default);
        }
     
        private static async Task<UpdateProductCommand> UpdateProduct(CreateProductCommand product)
        {
            var updateProductCommand = new UpdateProductCommand
            {
                Id = product.Id.ToString(),
                Name = "IFRI 1L",
                Description = "IFRI description test",
                Price = 80,
                EnergeticValue = 120,
                Picture = null
            };
            byte[] imageBytes = Properties.Resources.food_business;
            using (var castStream = new MemoryStream(imageBytes))
            {
                updateProductCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(updateProductCommand);
            };
            return updateProductCommand;
        }
    }
}
