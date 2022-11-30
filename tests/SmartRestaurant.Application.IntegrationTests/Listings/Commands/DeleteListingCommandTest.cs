using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Listings.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Listings.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteListingCommandTest:TestBase
    {
        [Test]

        public async Task shouldDeleteListing()
        {
            var newListing = await ListingTestTools.CreateListing();
            var checkListingExistance = await FindAsync<Listing>(newListing.ListingId);
            checkListingExistance.Should().NotBeNull();

            await SendAsync(new DeleteListingCommand
            {
                Id = newListing.ListingId
            });
            var deletedListing = await FindAsync<Listing>(newListing.ListingId);
            deletedListing.Should().BeNull();
        } 
    }
}
