using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Queries
{
    using static Testing;
    [TestFixture]
    public class GetWarningIngredientOfOrderWithIllnessWebQueryTest : TestBase
    {

        [Test]
        public async Task shoul_get_SummaryIngredientsWthIllnessweb()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createIngredientCommand1 = await IngredientTestTools.CreateIngredient();
            var createIngredientCommand2 = await IngredientTestTools.CreateIngredient("test2", "test2", "test2");

            var createDishCommand1 = await DishTestTools.CreateDishWithSupplimentIngredient(fastFood.FoodBusinessId, createIngredientCommand1.Id, createIngredientCommand2.Id);
            var createDishCommand2 = await DishTestTools.CreateDishWithOutSuppliment(fastFood.FoodBusinessId, createIngredientCommand1.Id);
            var createDishCommand3 = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand2.Id);
            var (createIllnessCommand, createIllnessCommand2) = await IllnessTestTools.CreateIllnesswithDeffirentIngredients(createIngredientCommand1.Id, createIngredientCommand2.Id);

            var illnessid1 = await GetIllness(createIllnessCommand.Id);
            List<string> listOfIlnessIds = new List<string> { illnessid1.IllnessId.ToString() };
            var createIllnessUserCommandFirstTime = await IllnessUserTestTools.CreateIllnessUser(listOfIlnessIds);


            var query2 = new GetIlnessessbyUserQuery
            {
            };
            var result2 = await SendAsync(query2);


            result2.Data.Count.Should().Be(1);


            var query = new GetWarningIngredientOfOrderWithIllnessWebQuery()
            {
                SummaryIngredients = new List<SummaryQteIngredientOfDishDto>()
                {
                    new SummaryQteIngredientOfDishDto()
                    {
                        IdDish = createDishCommand1.Id.ToString(),
                        QteDish=1,
                        IngredientDishes = new List<SummaryQteIngredientDto>()
                        {
                            new SummaryQteIngredientDto() {

                                IdIngredient = createIngredientCommand1.Id.ToString(),
                                Quantity = 10
                            }
                        },
                        IdSupplement=new List<string>()
                        {
                            createDishCommand1.Supplements[0].SupplementId
                        }
                    },
                    new SummaryQteIngredientOfDishDto()
                    {
                        IdDish = createDishCommand2.Id.ToString(),
                        QteDish=1,
                        IngredientDishes = new List<SummaryQteIngredientDto>()
                        {
                            new SummaryQteIngredientDto() {

                                IdIngredient = createIngredientCommand1.Id.ToString(),
                                Quantity = 10
                            }
                        },
                        IdSupplement=new List<string>()
                    },
                    new SummaryQteIngredientOfDishDto()
                    {
                        IdDish = createDishCommand3.Id.ToString(),
                        QteDish=1,
                        IngredientDishes = new List<SummaryQteIngredientDto>()
                        {
                            new SummaryQteIngredientDto() {

                                IdIngredient = createIngredientCommand2.Id.ToString(),
                                Quantity = 10
                            }
                        },
                        IdSupplement=new List<string>()
                        {
                            createDishCommand3.Supplements[0].SupplementId
                        }
                    }
                },

            };



            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.SummaryIngredientIllness.Count.Should().Be(1);
            result.SummaryIngredientIllness[0].IngredientId.Should().Be(createIngredientCommand1.Id.ToString());

            result.SummaryIngredientIllness[0].Illness[0].Quantity.Should().Equals(15);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.AR.Should().Be(createIllnessCommand.Names.AR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.EN.Should().Be(createIllnessCommand.Names.EN);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.FR.Should().Be(createIllnessCommand.Names.FR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.TR.Should().Be(createIllnessCommand.Names.TR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.RU.Should().Be(createIllnessCommand.Names.RU);

           


        }
    }
}
