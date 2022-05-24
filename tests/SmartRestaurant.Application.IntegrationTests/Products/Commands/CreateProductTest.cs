using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
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
            var createProductCommand = await ProductTestTools.CreateProduct();
            var createdProduct = await FindAsync<Product>(createProductCommand.Id);
            createdProduct.Should().NotBeNull();
            createdProduct.ProductId.Should().Be(createProductCommand.Id);
            createdProduct.Name.Should().BeEquivalentTo(createProductCommand.Name);
            
            createdProduct.Names.AR.Should().BeEquivalentTo(createProductCommand.Names.AR);
            createdProduct.Names.EN.Should().BeEquivalentTo(createProductCommand.Names.EN);
            createdProduct.Names.FR.Should().BeEquivalentTo(createProductCommand.Names.FR);
            createdProduct.Names.TR.Should().BeEquivalentTo(createProductCommand.Names.TR);
            createdProduct.Names.RU.Should().BeEquivalentTo(createProductCommand.Names.RU);

            createdProduct.Description.Should().Be(createProductCommand.Description);
            createdProduct.Price.Should().Be(150);
            createdProduct.EnergeticValue.Should().Be(200);
            createdProduct.CreatedBy.Should().Be(_authenticatedUserId);
            createdProduct.CreatedAt.Should().NotBe(default);
            createdProduct.LastModifiedBy.Should().BeNull();
            createdProduct.LastModifiedAt.Should().Be(default);
        }
    }
}
