using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Queries
{
    using static Testing;
    [TestFixture]
    public class GetIllnessesListTests
    {
        [Test]
        public async Task GetIllnessList()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            await IllnessTestTools.CreateIllness(createIngredientCommand.Id);

            var illnessesList_01 = await SendAsync(new GetIllnessesListQuery());
            illnessesList_01.Data.Should().HaveCount(2);

            var illnessesList_02 = await SendAsync(new GetIllnessesListQuery { CurrentFilter = "name", SearchKey = "allergie" });
            illnessesList_02.Data.Should().HaveCount(1);

            var illnessesList_03 = await SendAsync(new GetIllnessesListQuery { CurrentFilter = "name", SearchKey = "test" });
            illnessesList_03.Data.Should().HaveCount(1);

            var illnessesList_04 = await SendAsync(new GetIllnessesListQuery { CurrentFilter = "name", SearchKey = "diabete"});
            illnessesList_04.Data.Should().HaveCount(0);

        }
    }
}
