using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.HotelServices.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.HotelServices.Queries
{
    using static Testing;

    [TestFixture]
    public class GetHotelServicesListTest:TestBase
    {
        [Test]

        public async Task GetHotelServicesList()
        {
            var section = await HotelSectionTestTools.CreatetHotelSection_2();
            await HotelServicesTestTools.CreateHotelServicesList(10,section.HotelSectionId);
            var list = await SendAsync(new GetAllHotelServicesBySectionIdQuery { HotelSectionId = section.HotelSectionId.ToString() });

            list.Should().HaveCount(10);
            list[0].Parametres.Should().HaveCount(1);
           
        }

    }
}
