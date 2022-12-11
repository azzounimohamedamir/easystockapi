using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System.Threading.Tasks;
using SmartRestaurant.Application.ListingDetails.Commands;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.IntegrationTests.ListingDetails.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateListingDetailsCommandTests: TestBase
    {
        [Test]

        public async Task UpdateListingDetailShouldSaveToDb()
        {
            await RolesTestTools.CreateRoles();
            var newListingDetail = await ListingDetailsTestTools.CreateListingDetail();
            var updateListingDetailCommand = new UpdateListingDetailCommand
            {
                Id = newListingDetail.Id,
                ListingId = newListingDetail.ListingId,
                Picture = null,
                Names = new Names
                {
                    AR = "2رحلة بالقارب",
                    EN = "Boat trip2",
                    FR = "Balade en mer2",
                    TR = "Bot gezisi2",
                    RU = "Путешествие на лодке2"
                }
            };
            await SendAsync(updateListingDetailCommand);
            var updatedDetail = await FindAsync<ListingDetail>(newListingDetail.Id);
            updatedDetail.Names.AR.Should().Be("2رحلة بالقارب");
            updatedDetail.Names.EN.Should().Be("Boat trip2");
            updatedDetail.Names.FR.Should().Be("Balade en mer2");
            updatedDetail.Names.TR.Should().Be("Bot gezisi2");
            updatedDetail.Names.RU.Should().Be("Путешествие на лодке2");
        }
    }
}
