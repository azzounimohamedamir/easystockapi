using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Dishes.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Dishes.Queries
{
    using static Testing;

    [TestFixture]
    public class GetDishLisTest : TestBase
    {   
        [Test]
        public async Task GetDishList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);


            var dishesList_01 = await SendAsync(new GetDishesListQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_01.Data.Should().HaveCount(2);

            var dishesList_02 = await SendAsync(new GetDishesListQuery { CurrentFilter = "name", SearchKey = "Supplement" , FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_02.Data.Should().HaveCount(1);

            var dishesList_03 = await SendAsync(new GetDishesListQuery { CurrentFilter = "name", SearchKey = "Fakhitasse", FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_03.Data.Should().HaveCount(1);

            var dishesList_04 = await SendAsync(new GetDishesListQuery { CurrentFilter = "name", SearchKey = "test", FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_04.Data.Should().HaveCount(0);

        }
    }
}
