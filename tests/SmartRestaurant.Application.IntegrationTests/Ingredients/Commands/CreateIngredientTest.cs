using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Ingredients.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateIngredientTest : TestBase
    {    
        [Test]
        public async Task CreateIngredient_ShouldSaveToDB()
        {         
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createdIngredient = await FindAsync<Ingredient>(createIngredientCommand.Id);

            createdIngredient.Should().NotBeNull();
            createdIngredient.IngredientId.Should().Be(createIngredientCommand.Id);
            createdIngredient.Names.Should().Be(createIngredientCommand.Names);
            createdIngredient.EnergeticValue.Amount.Should().Be(createIngredientCommand.EnergeticValue.Amount);
            createdIngredient.EnergeticValue.MeasurementUnit.Should().Be(createIngredientCommand.EnergeticValue.MeasurementUnit);
            createdIngredient.EnergeticValue.Fat.Should().Be(createIngredientCommand.EnergeticValue.Fat);
            createdIngredient.EnergeticValue.Protein.Should().Be(createIngredientCommand.EnergeticValue.Protein);
            createdIngredient.EnergeticValue.Carbohydrates.Should().Be(createIngredientCommand.EnergeticValue.Carbohydrates);
            createdIngredient.EnergeticValue.Energy.Should().Be(createIngredientCommand.EnergeticValue.Energy);
            createdIngredient.Picture.Should().NotBeNull();
            createdIngredient.CreatedBy.Should().Be(_authenticatedUserId);
            createdIngredient.CreatedAt.Should().NotBe(default);
            createdIngredient.LastModifiedBy.Should().BeNull();
            createdIngredient.LastModifiedAt.Should().Be(default);
        }
    }
}
