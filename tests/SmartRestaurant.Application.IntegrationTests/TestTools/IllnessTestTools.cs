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
                Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto()
                    {
                        IngredientId = ingredientId
                    }
                }
            };
            var createIllnessCommand2 = new CreateIllnessCommand
            {
                Name = "allergie",
                Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto()
                    {
                        IngredientId = ingredientId
                    }
                }
            };
            await SendAsync(createIllnessCommand2);
            return createIllnessCommand;
        }
    }
}
