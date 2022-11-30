using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.Listings.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateListingCommandTests :TestBase
    {
        [Test]

        public async Task CreateListing_ShouldSaveToDb()
        {
            var newListing = await ListingTestTools.CreateListing();
            var expectedListing = await FindAsync<Listing>(newListing.ListingId);

            expectedListing.Should().NotBeNull();
            expectedListing.ListingId.Should().Be(newListing.ListingId);
            expectedListing.WithImage.Should().BeFalse();
            expectedListing.Names.AR.Should().BeEquivalentTo(newListing.Names.AR);
            expectedListing.Names.EN.Should().BeEquivalentTo(newListing.Names.EN);
            expectedListing.Names.FR.Should().BeEquivalentTo(newListing.Names.FR);
            expectedListing.Names.TR.Should().BeEquivalentTo(newListing.Names.TR);
            expectedListing.Names.RU.Should().BeEquivalentTo(newListing.Names.RU);
        }
    }
}
