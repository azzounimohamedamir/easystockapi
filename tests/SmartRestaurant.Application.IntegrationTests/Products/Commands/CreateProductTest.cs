using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
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

            var createProductCommand = await ProductTestTools.CreateProduct();
            var createdProduct = await FindAsync<Product>(createProductCommand.Id);
            createdProduct.Should().NotBeNull();
            createdProduct.ProductId.Should().Be(createProductCommand.Id);
            createdProduct.Name.Should().BeEquivalentTo(createProductCommand.Name);
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
