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


    public class GetAllHotelsByHotelReceptionistTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllHotelsAssignedToHotelReceptionistTests()
        {

            await RolesTestTools.CreateRoles();
           
            var IbisHotelFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var IbisAlger = await HotelTestTools.CreateHotel(IbisHotelFoodBusinessAdministrator.Id, "Ibis Hotel");
   


            var receptionistIbis = _authenticatedUserId;
            var assignReceptionitToIBISalger = new HotelUser
            {
                ApplicationUserId =receptionistIbis,
                HotelId = IbisAlger.Id
            };
            await AddAsync(assignReceptionitToIBISalger);

            

            


            var result = await SendAsync(new GetAllHotelsByHotelReceptionistQuery());

            result.Should().HaveCount(1);
            result.Should().NotBeNull();
        }
    }
}