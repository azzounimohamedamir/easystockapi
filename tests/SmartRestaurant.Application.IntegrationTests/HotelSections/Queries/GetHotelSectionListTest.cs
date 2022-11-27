using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.HotelSections.Queries;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelSections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetHotelSectionListTest : TestBase
    {
        [Test]
        public async Task GetHotelSectionList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Sofitel");
            await HotelSectionTestTools.CreateHotelSectionsList(6, hotel.Id);

            var hotelSectionsList_01 = await SendAsync(new GetSectionsListByHotelIdQuery
            {
                HotelId = hotel.Id.ToString(),
                Page = 1,
                PageSize = 5
            });
            hotelSectionsList_01.Data.Should().HaveCount(5);

            var hotelSectionsList_02 = await SendAsync(new GetSectionsListByHotelIdQuery { HotelId = hotel.Id.ToString(), Page = 1, PageSize = 5, CurrentFilter = "names", language="en", SearchKey = "maintenance 1 EN" });
            hotelSectionsList_02.Data.Should().HaveCount(1);
            var hotelSectionsList_03 = await SendAsync(new GetSectionsListByHotelIdQuery { HotelId = hotel.Id.ToString(), Page = 1, PageSize = 5, CurrentFilter = "names", language = "fr", SearchKey = "maintenance 1 FR" });
            hotelSectionsList_03.Data.Should().HaveCount(1);
        }
    }
}
