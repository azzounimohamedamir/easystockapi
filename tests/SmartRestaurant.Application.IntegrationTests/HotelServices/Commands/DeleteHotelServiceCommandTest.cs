using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;
using SmartRestaurant.Application.HotelServices.Commands;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.HotelServices.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteHotelServiceCommandTest:TestBase
    {
        [Test]

        public async Task deleteServiceTest()
        {
            var service = await HotelServicesTestTools.createHotelService();
            var command = new DeleteHotelServiceCommand { Id=service.Id};

            await SendAsync(command);
            var deletedService = await FindAsync<HotelService>(service.Id);

            deletedService.Should().BeNull();
        }
    }
}
