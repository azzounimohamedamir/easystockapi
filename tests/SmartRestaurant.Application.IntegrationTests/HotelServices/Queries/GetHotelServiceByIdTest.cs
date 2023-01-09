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
    public class GetHotelServiceByIdTest: TestBase
    {
        [Test]

        public async Task GetHotelService()
        {

            var service =  await HotelServicesTestTools.createHotelService();
            var query = await SendAsync(new GetHotelServiceByIdQuery { Id = service.Id.ToString() });

            query.Should().NotBeNull(); 
            query.Names.Should().BeEquivalentTo(service.Names);
            query.Id.Should().Be(service.Id);
            query.Parametres.Should().HaveCount(1);
        }
    }
}
