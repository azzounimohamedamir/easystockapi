using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Products.Queries;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Products.Commands
{
    using static Testing;

    [TestFixture]
    public class GetProductByIdTest : TestBase
    {   
        [Test]
        public async Task GetProductById_ShouldReturnSelectedProduct()
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


            var product = await ProductTestTools.CreateProduct_2();
            var selectedProduct = await SendAsync(new GetProductByIdQuery { Id = product.ProductId.ToString() });
            selectedProduct.Should().NotBeNull();
            selectedProduct.ProductId.Should().Be(product.ProductId);
            selectedProduct.Name.Should().BeEquivalentTo(product.Name);
            selectedProduct.Description.Should().Be(product.Description);
            selectedProduct.Price.Should().Be(product.Price);
            selectedProduct.EnergeticValue.Should().Be(product.EnergeticValue);
            selectedProduct.Picture.Should().Be(Convert.ToBase64String(product.Picture));
        }


    }
}
