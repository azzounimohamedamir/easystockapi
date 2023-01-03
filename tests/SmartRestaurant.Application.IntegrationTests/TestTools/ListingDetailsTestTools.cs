using System;
using System.Threading.Tasks;
using SmartRestaurant.Domain.ValueObjects;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.ListingDetails.Commands;


namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class ListingDetailsTestTools
    {
        public static async Task<ListingDetail> CreateListingDetail()
        {
          
            var listing = await ListingTestTools.CreateListing();
            var listingDetailCommand = new CreateListingDetailCommand
               
            { ListingId=listing.ListingId,
                Names = new Names
                {
                    AR = "رحلة بالقارب",
                    EN = "Boat trip",
                    FR = "Balade en mer",
                    TR = "Bot gezisi",
                    RU = "Путешествие на лодке"
                },
                Picture=null
            };
            await SendAsync(listingDetailCommand);
            var newListingDetail = await FindAsync<ListingDetail>(listingDetailCommand.Id);
            return newListingDetail;

        }

    }
}
