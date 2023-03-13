using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Entities;
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
            var product = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);

            var updateProductCommand = await UpdateProduct(product);
            var updatedProduct = await FindAsync<Product>(Guid.Parse(updateProductCommand.Id));

            updatedProduct.Should().NotBeNull();
            updatedProduct.ProductId.Should().Be(product.Id);
            updatedProduct.Name.Should().BeEquivalentTo(updateProductCommand.Name);

            updatedProduct.Names.AR.Should().BeEquivalentTo(updateProductCommand.Names.AR);
            updatedProduct.Names.EN.Should().BeEquivalentTo(updateProductCommand.Names.EN);
            updatedProduct.Names.FR.Should().BeEquivalentTo(updateProductCommand.Names.FR);
            updatedProduct.Names.TR.Should().BeEquivalentTo(updateProductCommand.Names.TR);
            updatedProduct.Names.RU.Should().BeEquivalentTo(updateProductCommand.Names.RU);

            updatedProduct.Description.Should().Be(updateProductCommand.Description);
            updatedProduct.Price.Should().Be(updateProductCommand.Price);
            updatedProduct.EnergeticValue.Should().Be(updateProductCommand.EnergeticValue);
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
                Names = new NamesDto() { AR = "hamoud 2L AR updated", EN = "hamoud 2L EN updated", FR = "hamoud 2L FR updated", TR = "hamoud 2L TR updated", RU = "hamoud 2L RU updated" },
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
