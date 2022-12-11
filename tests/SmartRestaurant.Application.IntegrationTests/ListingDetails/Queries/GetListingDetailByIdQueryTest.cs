using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;
using SmartRestaurant.Application.ListingDetails.Queries;

namespace SmartRestaurant.Application.IntegrationTests.ListingDetails.Queries
{
    using static Testing;

    [TestFixture]
    public class GetListingDetailByIdQueryTest:TestBase
    {
        [Test]

        public async Task shouldReturnListingDetailById()
        {
            await RolesTestTools.CreateRoles();
            var newDetail = await ListingDetailsTestTools.CreateListingDetail();
            var query = new GetListingDetailByIdQuery { Id = newDetail.Id.ToString() };

            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Id.Should().Be(newDetail.Id);
            result.Names.Should().BeEquivalentTo(newDetail.Names);
           
        }
    }
}
