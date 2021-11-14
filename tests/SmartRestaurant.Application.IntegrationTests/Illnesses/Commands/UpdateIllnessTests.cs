using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
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

            var updateIllnessCommand = await UpdateIllness(illness);
            var updatedIllness = await GetIllness(Guid.Parse(updateIllnessCommand.Id));


            updatedIllness.Should().NotBeNull();
            updatedIllness.IllnessId.Should().Be(updateIllnessCommand.Id);
            updatedIllness.Name.Should().Be(updateIllnessCommand.Name);
            updatedIllness.IngredientIllnesses.Should().HaveCount(0);



        }

        private static async Task<UpdateIllnessCommand> UpdateIllness(Domain.Entities.Illness illness)
        {
            var updateIllnessCommand = new UpdateIllnessCommand
            {
                Id = illness.IllnessId.ToString(),
                Name = "Fakhitasse modified",
            };
            await SendAsync(updateIllnessCommand);
            return updateIllnessCommand;
        }
    }
}
