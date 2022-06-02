using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class IllnessTestTools
    {
        public static async Task<CreateIllnessCommand> CreateIllness(Guid ingredientId)
        {
            var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "test",
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "testAR",
                    EN = "testEN",
                    FR = "testFR",
                    TR = "testTR",
                    RU = "testRU"
                },
                Ingredients = new List<IngredientIllnessDto>()
                {
                    new IngredientIllnessDto()
                    {
                        IngredientId = ingredientId.ToString()
                    }
                }
            };
            await SendAsync(createIllnessCommand);
            var createIllnessCommand2 = new CreateIllnessCommand
            {
                Name = "allergie",
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "allergieAR",
                    EN = "allergieEN",
                    FR = "allergieFR",
                    TR = "allergieTR",
                    RU = "allergieRU"
                },
                Ingredients = new List<IngredientIllnessDto>()
                {
                   new IngredientIllnessDto()
                    {
                        IngredientId = ingredientId.ToString()
                    }
                }
            };
            await SendAsync(createIllnessCommand2);
            return createIllnessCommand;
        }
        public static async Task<CreateIllnessCommand> CreateIllnesswithDeffirentIngredients(Guid ingredientId, Guid ingredientId2)
        {
            var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "test",
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "testAR",
                    EN = "testEN",
                    FR = "testFR",
                    TR = "testTR",
                    RU = "testRU"
                },
                Ingredients = new List<IngredientIllnessDto>()
                {
                    new IngredientIllnessDto()
                    {
                        IngredientId = ingredientId.ToString()
                    }
                }
            };
            await SendAsync(createIllnessCommand);
            var createIllnessCommand2 = new CreateIllnessCommand
            {
                Name = "allergie",
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "allergieAR",
                    EN = "allergieEN",
                    FR = "allergieFR",
                    TR = "allergieTR",
                    RU = "allergieRU"
                },
                Ingredients = new List<IngredientIllnessDto>()
                {
                   new IngredientIllnessDto()
                    {
                        IngredientId = ingredientId2.ToString()
                    }
                }
            };
            await SendAsync(createIllnessCommand2);
            return createIllnessCommand;
        }
    }
}
