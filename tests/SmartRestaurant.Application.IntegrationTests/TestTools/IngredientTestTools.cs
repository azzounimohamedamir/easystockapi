using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class IngredientTestTools
    {
        public static async Task<CreateIngredientCommand> CreateIngredient(
            string namear= "الفلفل الاسود",
            string nameEn= "Black pepper",
            string nameFr= "Le poivre noir")
        {
            var createIngredientCommand = new CreateIngredientCommand
            {
                Names =$@"[{{'name':'{nameEn}','language':'en'}},{{'name':'{namear}','language':'ar'}},{{'name':'{nameFr}','language':'fr'}}]",
                EnergeticValue = new EnergeticValue
                {
                    Amount = 10,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 2,
                    Protein = 1,
                    Carbohydrates = 3,
                    Energy = 10
                }
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createIngredientCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "ingredient", "ingredient.png");
                await SendAsync(createIngredientCommand);
            };

            return createIngredientCommand;
        }

        public static async Task CreateIngredientsList(int numberOfIngredientsToCreate)
        {
            for (var i = 0; i < numberOfIngredientsToCreate; i++)
            {
                var createIngredientCommand = new CreateIngredientCommand
                {
                    Names = @"[{'name':'Red pepper','language':'en'},{'name':'الفلفل الاحمر','language':'ar'},{'name':'Poivron rouge','language':'fr'}]",
                    EnergeticValue = new EnergeticValue
                    {
                        Amount = 10 + i,
                        MeasurementUnit = MeasurementUnits.Gramme,
                        Fat = 2 + i,
                        Protein = 1 + i,
                        Carbohydrates = 3 + i,
                        Energy = 10 + i
                    }
                };

                byte[] imageBytes = Properties.Resources.food;
                using (var castStream = new MemoryStream(imageBytes))
                {
                    createIngredientCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "ingredient", "ingredient.png");
                    await SendAsync(createIngredientCommand);
                };
            }
            

        }
    }
}
