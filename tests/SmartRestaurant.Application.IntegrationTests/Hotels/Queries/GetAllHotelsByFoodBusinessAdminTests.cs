using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.Hotels.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Queries
{
    using static Testing;


    public class GetAllHotelsByFoodBusinessAdminTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllHotelsAssignedToFoodBusinessAdminTests()
        {
            await RolesTestTools.CreateRoles();
            var AzHotelFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);

            var AzMostaghanem = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Mostaghanem");
            var AzAlger = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Alger");
            var AzOran = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Oran");


            var query = new GetHotelsListByAdmin
            {
            };
            var result = await SendAsync(query);


            result.Should().HaveCount(3);
            result.Should().NotBeNull();
            result[0].PhoneNumber.CountryCode.Should().Be(213);
            result.ForEach(item => { item.NRC.Should().Be(485844); });
        }
    }
}