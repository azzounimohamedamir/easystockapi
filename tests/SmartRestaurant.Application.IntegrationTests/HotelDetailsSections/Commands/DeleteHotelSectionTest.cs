using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.HotelDetailsSections.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelDetailsSections.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteHotelDetailsSectionTest : TestBase
    {
        [Test]
        public async Task DeleteHotelDetailsSection_ShouldBeRemovedFromDB()
        {
            var section = await HotelDetailsSectionTestTools.CreateHotelDetailsSection();
            var checkHotelDetailsSectionExistance = await FindAsync<HotelDetailsSection>(section.Id);
            checkHotelDetailsSectionExistance.Should().NotBeNull();

            await SendAsync(new DeleteHotelDetailsSectionCommand { Id = section.Id.ToString() });
            var deletedHotelDetailsSection = await FindAsync<HotelDetailsSection>(section.Id);
            deletedHotelDetailsSection.Should().BeNull();
        }
    }
}
