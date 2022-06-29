using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Queries
{
    using static Testing;
    [TestFixture]
    public class GetWarningIngredientOfOrderWithIllnessQueryTest : TestBase
    {

        [Test]
        public async Task shoul_get_SummaryIngredientsWthIllness()
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

            var query = new GetWarningIngredientOfOrderWithIllnessQuery()
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
                SummaryIllness = new List<string>()
                {
                    createIllnessCommand.Id.ToString(),
                    createIllnessCommand2.Id.ToString()
                }
            };

            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.SummaryIngredientIllness.Count.Should().Be(2);
            result.SummaryIngredientIllness[0].IngredientId.Should().Be(createIngredientCommand1.Id.ToString());
            result.SummaryIngredientIllness[1].IngredientId.Should().Be(createIngredientCommand2.Id.ToString());

            result.SummaryIngredientIllness[0].Illness[0].Quantity.Should().Equals(15);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.AR.Should().Be(createIllnessCommand.Names.AR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.EN.Should().Be(createIllnessCommand.Names.EN);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.FR.Should().Be(createIllnessCommand.Names.FR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.TR.Should().Be(createIllnessCommand.Names.TR);
            result.SummaryIngredientIllness[0].Illness[0].IllnessName.RU.Should().Be(createIllnessCommand.Names.RU);

            result.SummaryIngredientIllness[1].Illness[0].Quantity.Should().Equals(20);
            result.SummaryIngredientIllness[1].Illness[0].IllnessName.EN.Should().Be(createIllnessCommand2.Names.EN);
            result.SummaryIngredientIllness[1].Illness[0].IllnessName.FR.Should().Be(createIllnessCommand2.Names.FR);
            result.SummaryIngredientIllness[1].Illness[0].IllnessName.TR.Should().Be(createIllnessCommand2.Names.TR);
            result.SummaryIngredientIllness[1].Illness[0].IllnessName.RU.Should().Be(createIllnessCommand2.Names.RU);
            result.SummaryIngredientIllness[1].Illness[0].IllnessName.AR.Should().Be(createIllnessCommand2.Names.AR);


            result.SummaryIngredientIllness[0].Dishes[0].IdDish.Should().Be(createDishCommand1.Id.ToString());
            result.SummaryIngredientIllness[0].Dishes[0].InSuplement.Should().Be(false);
            result.SummaryIngredientIllness[0].Dishes[1].IdDish.Should().Be(createDishCommand2.Id.ToString());
            result.SummaryIngredientIllness[0].Dishes[1].InSuplement.Should().Be(false);

            result.SummaryIngredientIllness[1].Dishes[0].IdDish.Should().Be(createDishCommand1.Id.ToString());
            result.SummaryIngredientIllness[1].Dishes[0].InSuplement.Should().Be(true);
            result.SummaryIngredientIllness[1].Dishes[1].IdDish.Should().Be(createDishCommand3.Id.ToString());
            result.SummaryIngredientIllness[1].Dishes[1].InSuplement.Should().Be(false);
        }
    }
}
