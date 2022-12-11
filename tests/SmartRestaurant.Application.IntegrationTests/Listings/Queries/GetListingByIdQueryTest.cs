using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Listings.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Listings.Queries
{
    using static Testing;

    [TestFixture]
    public class GetListingByIdQueryTest:TestBase
    {
        [Test]

        public async Task shouldReturnListingById()
        {
            await RolesTestTools.CreateRoles();
            var newListing = await ListingTestTools.CreateListing();
            var query = new GetListingByIdQuery { Id = newListing.ListingId.ToString() };

            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.ListingId.Should().Be(newListing.ListingId.ToString());
            result.ListingDetails.Should().BeNullOrEmpty();
            result.WithImage.Should().BeFalse();
            result.Names.Should().BeEquivalentTo(newListing.Names);
        }
           
    }
}
