using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class HotelTestTools
    {
        public static async Task<Domain.Entities.Hotel> CreateHotel(string foodBusinessAdministratorId, string HotelName)
        {
            var hotelCommand = new CreateHotelCommand()
            {
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",

                Name = HotelName,
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                NIF = 121115,
                NIS = 25544855,
                ImagUrl = "assets/dldldld",
                NRC = 485844,
                Email = "madina@hotel.dz",
                Website = "",
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
            };


            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                hotelCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(hotelCommand);
            };
            var hotel = await FindAsync<Domain.Entities.Hotel>(hotelCommand.Id);
            return hotel;
        }

       
    }
}