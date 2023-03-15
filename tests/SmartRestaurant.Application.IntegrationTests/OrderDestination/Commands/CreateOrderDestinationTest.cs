using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.OrderDestination.Commands
{
    using static Testing;

    public class CreateOrderDestinationTest:TestBase
    {
        [Test]
        public async Task CreateOrderDestinationCommandTest_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");

            var createOrderDestinationCommand = await OrderDestinationTestTools.CreateOrderDestination(hotel.Id);
            var item = await FindAsync<Domain.Entities.OrderDestination>(createOrderDestinationCommand.Id);

            item.Should().NotBeNull();
            item.Names.AR.Should().Be("خدمات صحية");
            item.Names.EN.Should().Be("Healthy Service");
            item.Names.FR.Should().Be("Healthy Service");
            item.Names.TR.Should().Be("Healthy Service");
            item.Names.RU.Should().Be("Healthy Service");
            item.OrderDestinationId.Should().Be(createOrderDestinationCommand.Id);
        }
    }
}
