using System;
using System.Threading.Tasks;
using SmartRestaurant.Domain.ValueObjects;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Listings.Commands;


namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
   
    public class ListingTestTools
    {
        public static async Task<Listing> CreateListing()
        {
            await RolesTestTools.CreateRoles();

            var foodBusinessAdmin = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdmin.Id,"Marco Polo");

            var createListingCommand = new CreateListingCommand
            {
                HotelId = hotel.Id,
                Names = new Names
                {
                    AR = "رحلة بالقارب",
                    EN = "Boat trip",
                    FR = "Balade en mer",
                    TR = "Bot gezisi",
                    RU = "Путешествие на лодке"
                },
                WithImage = false,
            };
            await SendAsync(createListingCommand);
            var newListing = await FindAsync<Listing>(createListingCommand.Id);
            return newListing;
        }

        public static async Task CreateListOfListing(int numberOfListings,Guid hotelId)
        {
            for(int i = 0; i < numberOfListings; i++)
            {
                var createListingCommand = new CreateListingCommand
                {
                    HotelId = hotelId ,
                    Names = new Names
                    {
                        AR = $"رحلة بالقارب{i}",
                        EN = $"Boat trip{i}",
                        FR = $"Balade en mer{i}",
                        TR = $"Bot gezisi{i}",
                        RU = $"Путешествие на лодке{i}"
                    },
                    WithImage = false,
                };
                await SendAsync(createListingCommand);
            }
        }

    }
}
