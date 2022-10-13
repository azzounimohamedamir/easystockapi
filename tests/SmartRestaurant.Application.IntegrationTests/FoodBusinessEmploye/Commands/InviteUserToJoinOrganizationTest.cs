using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessEmploye.Commands
{
    using static Testing;
    [TestFixture]

    public class InviteUserToJoinOrganizationTest : TestBase
    {
        [Test]
        public async Task SaveManagerHotelOrFoodBusiness_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelIbis = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id,"Ibis Oran");
            var hotelmercure = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Mercure");

            var HotelsIds = new List<string> { hotelIbis.Id.ToString(), hotelmercure.Id.ToString() };
            var roles = new List<string> { Roles.FoodBusinessManager.ToString() };
            var email = "smartrest@gmail.com";
            var SendInviteToBecomeManagerHOtelCommand = new InviteUserToJoinOrganizationCommand
            {
              businessesIds = HotelsIds,
              Email=email,
              Roles = roles, 
              Typeinvitation = TypeInvitation.hotel
            };
            
            await SendAsync(SendInviteToBecomeManagerHOtelCommand);
            var userid = await GetUsers(email);
            foreach (var hotelid in SendInviteToBecomeManagerHOtelCommand.businessesIds)
            {
                var result= await GetHotelByIdUser(userid,Guid.Parse(hotelid));
                result.Should().Be(true);
            }
        }
    }
}
