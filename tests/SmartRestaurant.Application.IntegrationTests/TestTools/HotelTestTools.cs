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
        public static async Task<CreateHotelCommand> CreateHotel()
        {
            var createHotelCommand = new CreateHotelCommand
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

                Name = "MADINA HOTEL",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                NIF = 121115,
                NIS = 25544855,
                NRC=485844,
                Email = "madina@hotel.dz",
                Website = "",
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createHotelCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "hotel.png");
                await SendAsync(createHotelCommand);
            }

            return createHotelCommand;
        }

        public static async Task<Domain.Entities.Hotel> CreateFoodBusiness(string foodBusinessAdministratorId)
        {
            var createFoodBusinessCommand = new CreateHotelCommand
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
               
                Name = "Salam hotel",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
            };
            await SendAsync(createFoodBusinessCommand);
            var hotel = await FindAsync<Domain.Entities.Hotel>(createFoodBusinessCommand.Id);
            return hotel;
        }

        public static async Task<Domain.Entities.Hotel> CreateHotel(string foodBusinessAdministratorId, string HotelName)
        {
            var createFoodBusinessCommand = new CreateHotelCommand
            {
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                   
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
              
                Name = HotelName,
               
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
               
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
            };
            await SendAsync(createFoodBusinessCommand);
            var hotel = await FindAsync<Domain.Entities.Hotel>(createFoodBusinessCommand.Id);
            return hotel;
        }
    }
}