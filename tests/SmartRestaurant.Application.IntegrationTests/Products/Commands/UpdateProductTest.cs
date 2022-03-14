using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
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
            var product = await ProductTestTools.CreateProduct();

            var updateProductCommand = await UpdateProduct(product);
            var updatedProduct = await FindAsync<Product>(Guid.Parse(updateProductCommand.Id));

            updatedProduct.Should().NotBeNull();
            updatedProduct.ProductId.Should().Be(product.Id);
            updatedProduct.Name.Should().BeEquivalentTo(updateProductCommand.Name);
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
