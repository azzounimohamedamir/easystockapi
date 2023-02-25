using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.HotelDetailsSections.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelDetailsSections.Commands
{
    using static Testing;

    [TestFixture]
    internal class UpdateHotelDetailsSectionTest : TestBase
    {
        [Test]
        public async Task UpdateHotelDetailsSection_ShouldSaveToDB()
        {
            var section = await HotelDetailsSectionTestTools.CreateHotelDetailsSection();

            var updateHotelDetailsSectionCommand = await UpdateHotelDetailsSection(section);
            var updatedHotelDetailsSection = await FindAsync<HotelDetailsSection>(Guid.Parse(updateHotelDetailsSectionCommand.hotelSetionId));

            updatedHotelDetailsSection.Should().NotBeNull();
            updatedHotelDetailsSection.HotelDetailsSectionId.Should().Be(section.Id);

            updatedHotelDetailsSection.Description.Should().BeEquivalentTo(updateHotelDetailsSectionCommand.Description);
          

        }

        private static async Task<UpdateHotelDetailsSectionCommand> UpdateHotelDetailsSection(CreateHotelDetailsSectionCommand section)
        {
            var updateHotelDetailsSectionCommand = new UpdateHotelDetailsSectionCommand
            {
                hotelSetionId = section.Id.ToString(),
                Description = "description",
                HotelId = section.HotelId.ToString(),
                Picture = null
            };
            byte[] imageBytes = Properties.Resources.food_business;
            using (var castStream = new MemoryStream(imageBytes))
            {
                updateHotelDetailsSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "hotel.png");
                await SendAsync(updateHotelDetailsSectionCommand);
            };
            return updateHotelDetailsSectionCommand;
        }
    }
}
