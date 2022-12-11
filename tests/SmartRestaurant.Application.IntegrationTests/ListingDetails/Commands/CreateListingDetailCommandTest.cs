using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.ListingDetails.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateListingDetailCommandTest: TestBase
    {
        [Test]

        public async Task CreateListingDetail_ShouldSaveToDb()
        {
            await RolesTestTools.CreateRoles();
            var newListingDetail = await ListingDetailsTestTools.CreateListingDetail();
            var expectedDetail = await FindAsync<ListingDetail>(newListingDetail.Id);

            expectedDetail.Should().NotBeNull();
            expectedDetail.Id.Should().Be(newListingDetail.Id);
        }
    }
}
