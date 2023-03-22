using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.HotelSections.Commands;
using SmartRestaurant.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class HotelSectionTestTools
    {
        public static async Task<CreateHotelSectionCommand> CreateHotelSection()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Sofitel");
            var createHotelSectionCommand = new CreateHotelSectionCommand
            {
                Names = new NamesDto() { AR = "maintenance AR", EN = "maintenance EN", FR = "maintenance FR", TR = "maintenance TR", RU = "maintenance RU" },
                HotelId = hotel.Id
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createHotelSectionCommand);
            };

            return createHotelSectionCommand;
        }


        public static async Task<CreateHotelSectionCommand> CreateHotelSectionByHotelid(Guid hotelid)
        {
            var createHotelSectionCommand = new CreateHotelSectionCommand
            {
                Names = new NamesDto() { AR = "شيراطون مول", EN = "Sheraton Mall", FR = "Centre Commercial Sheraton", TR = "Sheraton Mall", RU = "Sheraton Mall" },
                HotelId = hotelid
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createHotelSectionCommand);
            };

            return createHotelSectionCommand;
        }

        public static async Task<HotelSection> CreatetHotelSection_2()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Sofitel");
            var createHotelSectionCommand = new CreateHotelSectionCommand
            {
                Names = new NamesDto()
                {
                    AR = "maintenance AR",
                    EN = "maintenance EN",
                    FR = "maintenance FR",
                    TR = "maintenance TR",
                    RU = "maintenance RU"
                },
                HotelId = hotel.Id
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createHotelSectionCommand);
            };

            return await FindAsync<HotelSection>(createHotelSectionCommand.Id);
        }

        public static async Task CreateHotelSectionsList(int numberOfHotelSectionsToCreate , Guid hotelId)
        {
            for (var i = 0; i < numberOfHotelSectionsToCreate; i++)
            {
                var createHotelSectionCommand = new CreateHotelSectionCommand
                {
                    Names = new NamesDto()
                    {
                        AR = $"maintenance {i} AR",
                        EN = $"maintenance {i} EN",
                        FR = $"maintenance {i} FR",
                        TR = $"maintenance {i} TR",
                        RU = $"maintenance {i} RU"
                    },
                    HotelId = hotelId
                };

                byte[] imageBytes = Properties.Resources.food;
                using (var castStream = new MemoryStream(imageBytes))
                {
                    createHotelSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                    await SendAsync(createHotelSectionCommand);
                };
            }
        }
    }
}
