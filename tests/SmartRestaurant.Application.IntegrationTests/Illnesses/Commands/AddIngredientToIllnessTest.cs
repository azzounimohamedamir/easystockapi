using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;

    [TestFixture]
    public class AddIngredientToIllnessTest : TestBase
    {
        [Test]
        public async Task AddIngredientToIllness_ShouldSaveToDB()
        {
           
             var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "Illness test"
            };
            await SendAsync(createIllnessCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();

            var addIngredientToIllnessCommand = new AddIngredientToIllnessCommand
            {
                IllnessId = createIllnessCommand.Id.ToString(),
                IngredientId = createIngredientCommand.Id.ToString(),
            };
            await SendAsync(addIngredientToIllnessCommand);
            var item = Where<IngredientIllness>(x =>
            x.IllnessId == Guid.Parse(addIngredientToIllnessCommand.IllnessId) &&
            x.IngredientId == Guid.Parse(addIngredientToIllnessCommand.IngredientId));

            item.Should().NotBeNull();
            item.Should().HaveCount(1);
            item[0].IllnessId.Should().Be(addIngredientToIllnessCommand.IllnessId);
            item[0].IngredientId.Should().Be(addIngredientToIllnessCommand.IngredientId);
        }
    }
}
