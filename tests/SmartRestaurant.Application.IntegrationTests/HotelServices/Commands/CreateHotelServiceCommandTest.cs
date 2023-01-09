using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.HotelServices.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateHotelServiceCommandTest:TestBase
    {
        [Test]

        public async Task CreateServiceTest()
        {
            var service = await HotelServicesTestTools.createHotelService();
            var createdService = await FindAsync<HotelService>(service.Id);

            createdService.Should().NotBeNull();
            createdService.Id.Should().Be(service.Id);
        }
    }
}
