using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelSections.Commands
{
    using static Testing;

    [TestFixture]

    internal class CreateHotelSectionTest: TestBase
    {
        [Test]

        public async Task CreateHotelSection_ShouldSaveToDB()
        {
            var createHotelSectionCommand = await HotelSectionTestTools.CreateHotelSection();
            var createdHotelSection = await FindAsync<HotelSection>(createHotelSectionCommand.Id);
            createdHotelSection.Should().NotBeNull();
            createdHotelSection.HotelSectionId.Should().Be(createHotelSectionCommand.Id);

            createdHotelSection.Names.AR.Should().BeEquivalentTo(createHotelSectionCommand.Names.AR);
            createdHotelSection.Names.EN.Should().BeEquivalentTo(createHotelSectionCommand.Names.EN);
            createdHotelSection.Names.FR.Should().BeEquivalentTo(createHotelSectionCommand.Names.FR);
            createdHotelSection.Names.TR.Should().BeEquivalentTo(createHotelSectionCommand.Names.TR);
            createdHotelSection.Names.RU.Should().BeEquivalentTo(createHotelSectionCommand.Names.RU);
        }
    }
}
