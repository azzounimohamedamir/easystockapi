using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Products.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteProductTest : TestBase
    {   
        [Test]
        public async Task DeleteProduct_ShouldBeRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var product = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var checkProductExistance = await FindAsync<Product>(product.Id);
            checkProductExistance.Should().NotBeNull();

            await SendAsync(new DeleteProductCommand { Id = product.Id.ToString() });
            var deletedProduct = await FindAsync<Product>(product.Id);
            deletedProduct.Should().BeNull();
        }
     
       
    }
}
