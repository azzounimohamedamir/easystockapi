using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.HotelDetailsSections.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelDetailsSections.Commands
{
    using static Testing;

    [TestFixture]
    public class GetHotelDetailsSectionByIdTest: TestBase
    {
        [Test]
        public async Task GetHotelDetailsSectionById_ShouldReturnSelectedHotelDetailsSection()
        {
            var section = await HotelDetailsSectionTestTools.CreatetHotelDetailsSection_2();
            var selectedHotelDetailsSection = await SendAsync(new GetHotelDetailsSectionByIdQuery { Id = section.HotelDetailsSectionId.ToString() });
            selectedHotelDetailsSection.Should().NotBeNull();
            selectedHotelDetailsSection.HotelDetailsSectionId.Should().Be(section.HotelDetailsSectionId);

            selectedHotelDetailsSection.Description.Should().BeEquivalentTo(section.Description);
           

            selectedHotelDetailsSection.Picture.Should().Be(Convert.ToBase64String(section.Picture));
        }

    }
}
