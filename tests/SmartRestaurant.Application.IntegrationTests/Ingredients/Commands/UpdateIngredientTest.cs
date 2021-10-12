using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Ingredients.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateIngredientTest : TestBase
    {   
        [Test]
        public async Task UpdateProductWithSectionAsParent_ShouldSaveToDB()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var ingredient = await FindAsync<Ingredient>(createIngredientCommand.Id);

            var updateIngredientCommand = await UpdateIngredient(ingredient);
            var updatedIngredient = await FindAsync<Ingredient>(Guid.Parse(updateIngredientCommand.Id));

            updatedIngredient.Should().NotBeNull();
            updatedIngredient.IngredientId.Should().Be(updateIngredientCommand.Id);
            updatedIngredient.Names.Should().Be(updateIngredientCommand.Names);
            updatedIngredient.EnergeticValue.Amount.Should().Be(updateIngredientCommand.EnergeticValue.Amount);
            updatedIngredient.EnergeticValue.MeasurementUnit.Should().Be(updateIngredientCommand.EnergeticValue.MeasurementUnit);
            updatedIngredient.EnergeticValue.Fat.Should().Be(updateIngredientCommand.EnergeticValue.Fat);
            updatedIngredient.EnergeticValue.Protein.Should().Be(updateIngredientCommand.EnergeticValue.Protein);
            updatedIngredient.EnergeticValue.Carbohydrates.Should().Be(updateIngredientCommand.EnergeticValue.Carbohydrates);
            updatedIngredient.EnergeticValue.Energy.Should().Be(updateIngredientCommand.EnergeticValue.Energy);
            updatedIngredient.Picture.Should().NotBeNull();
            updatedIngredient.Picture.Should().NotEqual(ingredient.Picture);
            updatedIngredient.CreatedBy.Should().NotBeNull();
            updatedIngredient.CreatedAt.Should().NotBe(default);
            updatedIngredient.LastModifiedBy.Should().Be(_authenticatedUserId);
            updatedIngredient.LastModifiedAt.Should().NotBe(default);
        }     
     
        private static async Task<UpdateIngredientCommand> UpdateIngredient(Ingredient ingredient)
        {
            var updateIngredientCommand = new UpdateIngredientCommand
            {
                Id = ingredient.IngredientId.ToString(),
                Names = @"[{'name':'Red pepper','language':'en'},{'name':'الفلفل الاحمر','language':'ar'},{'name':'Poivron rouge','language':'fr'}]",
                EnergeticValue = new EnergeticValue
                {
                    Amount = 2,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 1,
                    Protein = 0.5f,
                    Carbohydrates = 2,
                    Energy = 1
                }
            };
            byte[] imageBytes = Properties.Resources.food_business;
            using (var castStream = new MemoryStream(imageBytes))
            {
                updateIngredientCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "food_business", "food_business.png");
                await SendAsync(updateIngredientCommand);
            };
            return updateIngredientCommand;
        }
    }
}
