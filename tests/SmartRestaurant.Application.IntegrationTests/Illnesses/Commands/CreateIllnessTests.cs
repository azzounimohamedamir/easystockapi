using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateIllnessTests : TestBase
    {
        [Test]
        public async Task CreateIllness_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIllnessCommand = await IllnessTestTools.CreateIllness(createIngredientCommand.Id);

            var item = await GetIllness(createIllnessCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("test");
            item.Names.AR.Should().Be("testAR");
            item.Names.EN.Should().Be("testEN");
            item.Names.FR.Should().Be("testFR");
            item.Names.TR.Should().Be("testTR");
            item.Names.RU.Should().Be("testRU");
            item.IllnessId.Should().Be(createIllnessCommand.Id);
            item.IngredientIllnesses.Should().HaveCount(1);
            item.IngredientIllnesses[0].Ingredient.IngredientId.Should().Be(Guid.Parse(createIllnessCommand.Ingredients[0].IngredientId));
            item.IngredientIllnesses[0].Quantity.Should().Equals(15);
        }
    }
}
