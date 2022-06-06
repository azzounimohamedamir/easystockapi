using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Queries
{
    using static Testing;

    [TestFixture]
    public class GetIllnessByIdTest : TestBase
    {        
        [Test]
        public async Task GetIllnessById_ShouldReturnSelectedIllness()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIllnessCommand = await IllnessTestTools.CreateIllness(createIngredientCommand.Id);
            var illness = await GetIllness(createIllnessCommand.Id);


            var selectedIllness = await SendAsync(new GetIllnessByIdQuery { Id = createIllnessCommand.Id.ToString() });
            selectedIllness.Should().NotBeNull();

            selectedIllness.IllnessId.Should().Be(illness.IllnessId);
            selectedIllness.Name.Should().Be(illness.Name);
            

            selectedIllness.IngredientIllnesses.Should().HaveCount(1);

            selectedIllness.IngredientIllnesses[0].IngredientId.Should().Be(illness.IngredientIllnesses[0].IngredientId.ToString());
            selectedIllness.IngredientIllnesses[0].Quantity.Should().Be(illness.IngredientIllnesses[0].Quantity);
            selectedIllness.IngredientIllnesses[0].Ingredient.Names.Should().BeEquivalentTo(JsonConvert.DeserializeObject<List<IngredientNameDto>>(illness.IngredientIllnesses[0].Ingredient.Names));
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.Amount.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.Amount);
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.MeasurementUnit.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.MeasurementUnit);
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.Fat.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.Fat);
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.Protein.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.Protein);
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.Carbohydrates.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.Carbohydrates);
            selectedIllness.IngredientIllnesses[0].Ingredient.EnergeticValue.Energy.Should().Be(illness.IngredientIllnesses[0].Ingredient.EnergeticValue.Energy);
            selectedIllness.IngredientIllnesses[0].Ingredient.Picture.Should().Be(Convert.ToBase64String(illness.IngredientIllnesses[0].Ingredient.Picture));

        }
    }
}
