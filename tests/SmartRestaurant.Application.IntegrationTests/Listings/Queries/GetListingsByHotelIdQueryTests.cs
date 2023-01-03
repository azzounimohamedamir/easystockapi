
using System.Threading.Tasks;
using FluentAssertions;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Listings.Queries;


namespace SmartRestaurant.Application.IntegrationTests.Listings.Queries
{
    using static Testing;
    public class GetListingsByHotelIdQueryTests : TestBase
    {
        public async Task shouldReturnAllListingsByHotelId()
        {
            await RolesTestTools.CreateRoles();

            var foodBusinessAdmin = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdmin.Id, "marco polo");

            await ListingTestTools.CreateListOfListing(10,hotel.Id);

            var query = new GetListingsByHotelIdQuery
            {
                HotelId = hotel.Id.ToString(),
                Page = 1,
                PageSize = 5,
            } ;
            var listOfListings = await SendAsync(query);

            listOfListings.Data.Should().NotBeNull();
            listOfListings.Data.Should().HaveCount(5);
        }
    }
}
