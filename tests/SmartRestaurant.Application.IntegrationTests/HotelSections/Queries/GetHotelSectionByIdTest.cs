using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.HotelSections.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelSections.Commands
{
    using static Testing;

    [TestFixture]
    public class GetHotelSectionByIdTest: TestBase
    {
        [Test]
        public async Task GetHotelSectionById_ShouldReturnSelectedHotelSection()
        {
            var section = await HotelSectionTestTools.CreatetHotelSection_2();
            var selectedHotelSection = await SendAsync(new GetHotelSectionByIdQuery { Id = section.HotelSectionId.ToString() });
            selectedHotelSection.Should().NotBeNull();
            selectedHotelSection.HotelSectionId.Should().Be(section.HotelSectionId);

            selectedHotelSection.Names.AR.Should().BeEquivalentTo(section.Names.AR);
            selectedHotelSection.Names.EN.Should().BeEquivalentTo(section.Names.EN);
            selectedHotelSection.Names.FR.Should().BeEquivalentTo(section.Names.FR);
            selectedHotelSection.Names.TR.Should().BeEquivalentTo(section.Names.TR);
            selectedHotelSection.Names.RU.Should().BeEquivalentTo(section.Names.RU);

            selectedHotelSection.Picture.Should().Be(Convert.ToBase64String(section.Picture));
        }

    }
}
