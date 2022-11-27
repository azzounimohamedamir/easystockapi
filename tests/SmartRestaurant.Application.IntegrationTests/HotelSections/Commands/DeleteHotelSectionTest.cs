using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.HotelSections.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelSections.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteHotelSectionTest : TestBase
    {
        [Test]
        public async Task DeleteHotelSection_ShouldBeRemovedFromDB()
        {
            var section = await HotelSectionTestTools.CreateHotelSection();
            var checkHotelSectionExistance = await FindAsync<HotelSection>(section.Id);
            checkHotelSectionExistance.Should().NotBeNull();

            await SendAsync(new DeleteHotelSectionCommand { Id = section.Id.ToString() });
            var deletedHotelSection = await FindAsync<HotelSection>(section.Id);
            deletedHotelSection.Should().BeNull();
        }
    }
}
