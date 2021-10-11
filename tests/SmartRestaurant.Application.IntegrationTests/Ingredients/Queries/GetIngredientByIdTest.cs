using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Ingredients.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Ingredients.Queries
{
    using static Testing;

    [TestFixture]
    public class GetIngredientByIdTest : TestBase
    {   
        [Test]
        public async Task GetProductById_ShouldReturnSelectedProduct()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var ingredient = await FindAsync<Ingredient>(createIngredientCommand.Id);

            var selectedIngredient = await SendAsync(new GetIngredientByIdQuery { Id = createIngredientCommand.Id.ToString() });
            selectedIngredient.Should().NotBeNull();
            selectedIngredient.IngredientId.Should().Be(createIngredientCommand.Id);
            selectedIngredient.Names.Should().BeEquivalentTo(JsonConvert.DeserializeObject<List<IngredientNameDto>>(createIngredientCommand.Names));
            selectedIngredient.EnergeticValue.Amount.Should().Be(createIngredientCommand.EnergeticValue.Amount);
            selectedIngredient.EnergeticValue.MeasurementUnit.Should().Be(createIngredientCommand.EnergeticValue.MeasurementUnit);
            selectedIngredient.EnergeticValue.Fat.Should().Be(createIngredientCommand.EnergeticValue.Fat);
            selectedIngredient.EnergeticValue.Protein.Should().Be(createIngredientCommand.EnergeticValue.Protein);
            selectedIngredient.EnergeticValue.Carbohydrates.Should().Be(createIngredientCommand.EnergeticValue.Carbohydrates);
            selectedIngredient.EnergeticValue.Energy.Should().Be(createIngredientCommand.EnergeticValue.Energy);
            selectedIngredient.Picture.Should().Be(Convert.ToBase64String(ingredient.Picture));
        }
    }
}
