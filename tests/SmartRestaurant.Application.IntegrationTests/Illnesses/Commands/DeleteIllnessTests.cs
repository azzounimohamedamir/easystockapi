using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;

    [TestFixture]
    class DeleteIllnessTests : TestBase
    {
        [Test]
        public async Task DeleteIllness_ShouldBeRemovedFromDB()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIllnessCommand = await IllnessTestTools.CreateIllness( createIngredientCommand.Id);
            var checkIllnessExistance = await FindAsync<Domain.Entities.Illness>(createIllnessCommand.Id);
            checkIllnessExistance.Should().NotBeNull();

            await SendAsync(new DeleteIllnessCommand { Id = createIllnessCommand.Id.ToString() });
            var deletedIllness = await FindAsync<Domain.Entities.Illness>(createIllnessCommand.Id);
            deletedIllness.Should().BeNull();
        }
    }
}
