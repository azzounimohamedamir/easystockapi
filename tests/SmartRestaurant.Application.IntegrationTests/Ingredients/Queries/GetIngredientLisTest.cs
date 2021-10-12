using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Ingredients.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Ingredients.Queries
{
    using static Testing;

    [TestFixture]
    public class GetIngredientLisTest : TestBase
    {   
        [Test]
        public async Task GetProductList()
        {     
            await IngredientTestTools.CreateIngredient();
            await IngredientTestTools.CreateIngredientsList(5);

            var productsList_01 = await SendAsync(new GetIngredientsListQuery { });
            productsList_01.Data.Should().HaveCount(6);

            var productsList_02 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "Red pepper" });
            productsList_02.Data.Should().HaveCount(5);

            var productsList_03 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "الفلفل الاحمر" });
            productsList_03.Data.Should().HaveCount(5);

            var productsList_04 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "Poivron rouge" });
            productsList_04.Data.Should().HaveCount(5);

            var productsList_05 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "Black pepper" });
            productsList_05.Data.Should().HaveCount(1);

            var productsList_06 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "الفلفل الاسود" });
            productsList_06.Data.Should().HaveCount(1);

            var productsList_07 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "Le poivre noir" });
            productsList_07.Data.Should().HaveCount(1);

            var productsList_08 = await SendAsync(new GetIngredientsListQuery { CurrentFilter = "name", SearchKey = "test" });
            productsList_08.Data.Should().HaveCount(0);

        }
    }
}
