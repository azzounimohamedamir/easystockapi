using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;
using SmartRestaurant.Application.ListingDetails.Commands;

namespace SmartRestaurant.Application.IntegrationTests.ListingDetails.Commands
{

    using static Testing;

    [TestFixture]
    public class DeleteListingDetailCommandTest : TestBase
    {
        [Test]

        public async Task DeleteListingDetail_fromDb()
        {
            await RolesTestTools.CreateRoles();
            var newDetail = await ListingDetailsTestTools.CreateListingDetail();
            var checkDetailExistance = await FindAsync<ListingDetail>(newDetail.Id);
            checkDetailExistance.Should().NotBeNull();

            await SendAsync(new DeleteListingDetailCommand { Id = newDetail.Id });
            var deletedDetail = await FindAsync<ListingDetail>(newDetail.Id);
            deletedDetail.Should().BeNull();
        }
    }
}
