using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
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
            var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "Illness test",
                Ingredients = new List<IngredientDto>()
                {
                    new IngredientDto()
                    {
                        IngredientId = createIngredientCommand.Id,
                        EnergeticValue= createIngredientCommand.EnergeticValue
                    }
                }
            };
            await SendAsync(createIllnessCommand);
            var item = await FindAsync<Domain.Entities.Illness>(createIllnessCommand.Id);
            
            item.Should().NotBeNull();
            item.Name.Should().Be("Illness test");
            item.IllnessId.Should().Be(createIllnessCommand.Id);
            foreach(IngredientDto ingredient in createIllnessCommand.Ingredients)
            {

                var item2 = Where<Domain.Entities.IngredientIllness>(x =>
                 x.IllnessId == createIllnessCommand.Id &&
                 x.IngredientId == ingredient.IngredientId);

                item2.Should().NotBeNull();
                item2.Should().HaveCount(1);
                item2[0].IllnessId.Should().Be(createIllnessCommand.Id);
                item2[0].IngredientId.Should().Be(ingredient.IngredientId);
            }
            
        }
    }
}
