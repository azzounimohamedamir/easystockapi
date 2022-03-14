using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Ingredients.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteIngredientTest : TestBase
    {   
        [Test]
        public async Task DeleteProduct_ShouldBeRemovedFromDB()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var checkIngredientExistance = await FindAsync<Ingredient>(createIngredientCommand.Id);
            checkIngredientExistance.Should().NotBeNull();

            await SendAsync(new DeleteIngredientCommand { Id = createIngredientCommand.Id.ToString() });
            var deletedIngredient = await FindAsync<Ingredient>(createIngredientCommand.Id);
            deletedIngredient.Should().BeNull();
        }
     
       
    }
}
