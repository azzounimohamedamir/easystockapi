using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Products.Queries;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Products.Commands
{
    using static Testing;

    [TestFixture]
    public class GetProductLisTest : TestBase
    {   
        [Test]
        public async Task GetProductList()
        {                         
            await ProductTestTools.CreateProductsList(5);

            var productsList_01 = await SendAsync(new GetProductListQuery { });
            productsList_01.Data.Should().HaveCount(5);

            var productsList_02 = await SendAsync(new GetProductListQuery { CurrentFilter = "name", SearchKey = "hamoud 2L 4" });
            productsList_02.Data.Should().HaveCount(1);

            var productsList_03 = await SendAsync(new GetProductListQuery { CurrentFilter = "description", SearchKey = "description test 2" });
            productsList_03.Data.Should().HaveCount(1);

            var productsList_04 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = "==" });
            productsList_04.Data.Should().HaveCount(1);

            var productsList_05 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = "!=" });
            productsList_05.Data.Should().HaveCount(4);

            var productsList_06 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = "<" });
            productsList_06.Data.Should().HaveCount(0);

            var productsList_07 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = "<=" });
            productsList_07.Data.Should().HaveCount(1);

            var productsList_08 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = ">" });
            productsList_08.Data.Should().HaveCount(4);

            var productsList_09 = await SendAsync(new GetProductListQuery { CurrentFilter = "price", SearchKey = "150", ComparisonOperator = ">=" });
            productsList_09.Data.Should().HaveCount(5);

            var productsList_10 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = "==" });
            productsList_10.Data.Should().HaveCount(1);

            var productsList_11 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = "!=" });
            productsList_11.Data.Should().HaveCount(4);

            var productsList_12 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = "<" });
            productsList_12.Data.Should().HaveCount(0);

            var productsList_13 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = "<=" });
            productsList_13.Data.Should().HaveCount(1);

            var productsList_14 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = ">" });
            productsList_14.Data.Should().HaveCount(4);

            var productsList_15 = await SendAsync(new GetProductListQuery { CurrentFilter = "energeticvalue", SearchKey = "200", ComparisonOperator = ">=" });
            productsList_15.Data.Should().HaveCount(5);
        }
    }
}
