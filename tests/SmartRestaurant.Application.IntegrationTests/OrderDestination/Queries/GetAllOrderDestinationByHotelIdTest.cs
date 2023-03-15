using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.OrderDestination.Queries;
using SmartRestaurant.Application.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.OrderDestination.Queries
{
    using static Testing;

    public class GetAllOrderDestinationByHotelIdTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllOrderDestinationByHotelIdTest()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");

            var createOrderDestinationCommand = await OrderDestinationTestTools.CreateOrderDestination(hotel.Id);

            var orderdestinationlist = await SendAsync(new GetAllOrderDestinationListByHotelId { HotelId = createOrderDestinationCommand.HotelId.ToString() });
            orderdestinationlist.Data.Should().HaveCount(1);
        }
    }
}
