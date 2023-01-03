using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Domain.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Listings.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Listings.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateListingCommandTest:TestBase
    {
        [Test]

        public async Task shouldUpdateListing()
        {
            await RolesTestTools.CreateRoles();
            var newlisting = await ListingTestTools.CreateListing();
            var updateListingCommand = new UpdateListingCommand
            {
                ListingId = newlisting.ListingId,
                Names = new Names {
                    AR = "2رحلة بالقارب",
                    EN = "Boat trip2",
                    FR = "Balade en mer2",
                    TR = "Bot gezisi2",
                    RU = "Путешествие на лодке2"
                },
                WithImage = true,
                HotelId = newlisting.HotelId,
            };
            await SendAsync(updateListingCommand);
            var updatedListing = await FindAsync<Listing>(newlisting.ListingId);

            updatedListing.ListingId.Should().Be(newlisting.ListingId);
            updatedListing.Names.AR.Should().Be("2رحلة بالقارب");
            updatedListing.Names.EN.Should().Be("Boat trip2");
            updatedListing.Names.FR.Should().Be("Balade en mer2");
            updatedListing.Names.TR.Should().Be("Bot gezisi2");
            updatedListing.Names.RU.Should().Be("Путешествие на лодке2");
            updatedListing.WithImage.Should().BeTrue();
        }
    }
}
