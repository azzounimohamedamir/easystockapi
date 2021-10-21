using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Dishes.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteDishTest : TestBase
    {   
        [Test]
        public async Task DeleteDish_ShouldBeRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var checkDishExistance = await FindAsync<Dish>(createDishCommand.Id);
            checkDishExistance.Should().NotBeNull();

            await SendAsync(new DeleteDishCommand { Id = createDishCommand.Id.ToString() });
            var deletedDish = await FindAsync<Dish>(createDishCommand.Id);
            deletedDish.Should().BeNull();
        }
     
       
    }
}
