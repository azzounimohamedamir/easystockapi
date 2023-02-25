using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelDetailsSections.Commands
{
    using static Testing;

    [TestFixture]

    internal class CreateHotelDetailsSectionTest: TestBase
    {
        [Test]

        public async Task CreateHotelDetailsSection_ShouldSaveToDB()
        {
            var createHotelDetailsSectionCommand = await HotelDetailsSectionTestTools.CreateHotelDetailsSection();
            var createdHotelDetailsSection = await FindAsync<HotelDetailsSection>(createHotelDetailsSectionCommand.Id);
            createdHotelDetailsSection.Should().NotBeNull();
            createdHotelDetailsSection.HotelDetailsSectionId.Should().Be(createHotelDetailsSectionCommand.Id);

            createdHotelDetailsSection.Description.Should().BeEquivalentTo(createHotelDetailsSectionCommand.Description);
          
        }
    }
}
