using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateIllnessTest : TestBase
    {
        [Test]
        public async Task UpdateIllness_ShouldSaveToDB()
        {

            await RolesTestTools.CreateRoles();
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();

            var createIllnessCommand = await IllnessTestTools.CreateIllness(createIngredientCommand.Id);
            var illness = await GetIllness(createIllnessCommand.Id);
            var createIngredientCommandForUpdate = await IngredientTestTools.CreateIngredient(
                "updated الفلفل الاسود",
                "Black pepper updated",
                "Le poivre noir updatet"
                );
            var updateIllnessCommand = await UpdateIllness(illness, createIngredientCommandForUpdate.Id.ToString());
            var updatedIllness = await GetIllness(Guid.Parse(updateIllnessCommand.Id));


            updatedIllness.Should().NotBeNull();
            updatedIllness.IllnessId.Should().Be(updateIllnessCommand.Id);
            updatedIllness.Name.Should().Be(updateIllnessCommand.Name);
            updatedIllness.Names.AR.Should().Be("Fakhitasse modifiedAR");
            updatedIllness.Names.EN.Should().Be("Fakhitasse modifiedEN");
            updatedIllness.Names.FR.Should().Be("Fakhitasse modifiedFR");
            updatedIllness.Names.TR.Should().Be("Fakhitasse modifiedTR");
            updatedIllness.Names.RU.Should().Be("Fakhitasse modifiedRU");
            updatedIllness.IngredientIllnesses.Should().HaveCount(1);


            updatedIllness.Names.AR.Should().Be("Fakhitasse modifiedAR");
            updatedIllness.Names.EN.Should().Be("Fakhitasse modifiedEN");
            updatedIllness.Names.FR.Should().Be("Fakhitasse modifiedFR");
            updatedIllness.Names.TR.Should().Be("Fakhitasse modifiedTR");
            updatedIllness.Names.RU.Should().Be("Fakhitasse modifiedRU");
            updatedIllness.IngredientIllnesses.Should().HaveCount(1);
            updatedIllness.IngredientIllnesses[0].IngredientId.Should().Be(createIngredientCommandForUpdate.Id);

        }

        private static async Task<UpdateIllnessCommand> UpdateIllness(Domain.Entities.Illness illness,string IngredientIdForUpdate)
        {
            var updateIllnessCommand = new UpdateIllnessCommand
            {
                Id = illness.IllnessId.ToString(),
                Name = "Fakhitasse modified",

                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "Fakhitasse modifiedAR",
                    EN = "Fakhitasse modifiedEN",
                    FR = "Fakhitasse modifiedFR",
                    TR = "Fakhitasse modifiedTR",
                    RU = "Fakhitasse modifiedRU"
                },
                Ingredients = new List<IngredientIllnessDto>()
                {
                    new IngredientIllnessDto()
                    {
                        IngredientId = IngredientIdForUpdate,
                        Quantity=15
                    }
                }
            };
            await SendAsync(updateIllnessCommand);
            return updateIllnessCommand;
        }
    }
}
