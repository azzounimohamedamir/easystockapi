using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Queries
{
    using static Testing;
    [TestFixture]
    public class GetDishesIllnessQueryTest : TestBase
    {
        [Test]
        public async Task GetDishesIllnessQuery_whenDishContainIngredientAndExisteIllnessWithThisIngredient_ShouldReturnTheDishIdWithTheCorrespondingIllnessOfEachIngredient()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIngredientCommand2 = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createIllnessCommand = await IllnessTestTools.CreateIllnesswithDeffirentIngredients(createIngredientCommand.Id, createIngredientCommand2.Id);

            var listDishesIllness = await SendAsync(new GetDishesIllnessQuery { 
                disheIds=new List<string>() { createDishCommand.Id.ToString() } ,
                illnesIds = new List<string>() { createIllnessCommand.Id.ToString() },
            });
            listDishesIllness.Should().NotBeNull();

            listDishesIllness[0].IdDishe.Should().Be(createDishCommand.Id.ToString());
            listDishesIllness[0].IllnessIngredients.Should().HaveCount(1);
            listDishesIllness[0].IllnessIngredients[0].IngredientId.Should().Be(createIngredientCommand.Id.ToString());
            listDishesIllness[0].IllnessIngredients[0].Illness.Should().HaveCount(1);
            listDishesIllness[0].IllnessIngredients[0].Illness[0].IllnessId.Should().Be(createIllnessCommand.Id.ToString());
            listDishesIllness[0].IllnessIngredients[0].Illness[0].Name.Should().Be(createIllnessCommand.Name);
        }
    }
}
