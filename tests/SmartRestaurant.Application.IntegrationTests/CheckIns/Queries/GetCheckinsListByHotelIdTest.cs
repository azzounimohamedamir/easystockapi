using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Checkins.Queries;
using SmartRestaurant.Application.Checkins.Commands;
using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.Checkins.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.CheckIns.Queries
{
    using static Testing;

    [TestFixture]
    public class GetCheckinsListByHotelIdTest : TestBase
    {
        [Test]
        public async Task ShouldGetCheckinsListByHotelIdTest()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var hotel = await HotelTestTools.CreateHotel(client.Id, "Shiraton");
            var hotel2 = await HotelTestTools.CreateHotel(client.Id, "Sofitel");

            var checkin1 = await CheckInsTestTools.Create_Draft_Checkin(hotel.Id);
            var checkin11 = await CheckInsTestTools.Create_Draft_Checkin(hotel.Id);

            var checkin2 = await CheckInsTestTools.Create_Draft_Checkin(hotel2.Id);


            var query = new GetCheckinsListQuery
            {
                hotelId = hotel.Id,
                Page = 1,
                PageSize = 5,
            };

           
            var listofCheckins = await SendAsync(query);

            listofCheckins.Data.Count.Should().Be(2);
            listofCheckins.Data[0].hotelId.Should().Be(hotel.Id);
            listofCheckins.Data[1].hotelId.Should().Be(hotel.Id);



        }
    }
}
