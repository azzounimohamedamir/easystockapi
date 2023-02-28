using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.HotelDetailsSections.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class HotelDetailsSectionTestTools
    {
        public static async Task<CreateHotelDetailsSectionCommand> CreateHotelDetailsSection()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Sofitel");
            var createHotelDetailsSectionCommand = new CreateHotelDetailsSectionCommand
            {
                Description = "description",
                HotelId = hotel.Id
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelDetailsSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "hotel.png");
                await SendAsync(createHotelDetailsSectionCommand);
            };

            return createHotelDetailsSectionCommand;
        }

        public static async Task<HotelDetailsSection> CreatetHotelDetailsSection_2()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Sofitel");
            var createHotelDetailsSectionCommand = new CreateHotelDetailsSectionCommand
            {
                Description ="description2",
                HotelId = hotel.Id
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelDetailsSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createHotelDetailsSectionCommand);
            };

            return await FindAsync<HotelDetailsSection>(createHotelDetailsSectionCommand.Id);
        }

        public static async Task CreateHotelDetailsSectionsList(int numberOfHotelDetailsSectionsToCreate , Guid hotelId)
        {
            for (var i = 0; i < numberOfHotelDetailsSectionsToCreate; i++)
            {
                var createHotelDetailsSectionCommand = new CreateHotelDetailsSectionCommand
                {
                    Description = $"Description {i} ",
                      
                    HotelId = hotelId
                };

                byte[] imageBytes = Properties.Resources.food;
                using (var castStream = new MemoryStream(imageBytes))
                {
                    createHotelDetailsSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "hotel.png");
                    await SendAsync(createHotelDetailsSectionCommand);
                };
            }
        }
    }
}
