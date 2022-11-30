using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.HotelSections.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelSections.Commands
{
    using static Testing;

    [TestFixture]
    internal class UpdateHotelSectionTest : TestBase
    {
        [Test]
        public async Task UpdateHotelSection_ShouldSaveToDB()
        {
            var section = await HotelSectionTestTools.CreateHotelSection();

            var updateHotelSectionCommand = await UpdateHotelSection(section);
            var updatedHotelSection = await FindAsync<HotelSection>(Guid.Parse(updateHotelSectionCommand.hotelSetionId));

            updatedHotelSection.Should().NotBeNull();
            updatedHotelSection.HotelSectionId.Should().Be(section.Id);

            updatedHotelSection.Names.AR.Should().BeEquivalentTo(updateHotelSectionCommand.Names.AR);
            updatedHotelSection.Names.EN.Should().BeEquivalentTo(updateHotelSectionCommand.Names.EN);
            updatedHotelSection.Names.FR.Should().BeEquivalentTo(updateHotelSectionCommand.Names.FR);
            updatedHotelSection.Names.TR.Should().BeEquivalentTo(updateHotelSectionCommand.Names.TR);
            updatedHotelSection.Names.RU.Should().BeEquivalentTo(updateHotelSectionCommand.Names.RU);

        }

        private static async Task<UpdateHotelSectionCommand> UpdateHotelSection(CreateHotelSectionCommand section)
        {
            var updateHotelSectionCommand = new UpdateHotelSectionCommand
            {
                hotelSetionId = section.Id.ToString(),
                Names = new NamesDto() { AR = "maintenance AR updated", EN = "maintenance EN updated", FR = "maintenance FR updated", TR = "maintenance TR updated", RU = "maintenance RU updated" },
                HotelId = section.HotelId.ToString(),
                Picture = null
            };
            byte[] imageBytes = Properties.Resources.food_business;
            using (var castStream = new MemoryStream(imageBytes))
            {
                updateHotelSectionCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(updateHotelSectionCommand);
            };
            return updateHotelSectionCommand;
        }
    }
}
