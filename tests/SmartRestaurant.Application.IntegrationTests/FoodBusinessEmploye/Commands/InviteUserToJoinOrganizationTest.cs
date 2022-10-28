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


            var hotelCheraton = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Cheraton");
            var HotelsIds2 = new List<string> { hotelCheraton.Id.ToString() };

            var McDonald= await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id, "Mcdonald");
            var foodIds = new List<string> { McDonald.FoodBusinessId.ToString() };

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
                var result = await GetHotelByIdUser(userid, Guid.Parse(hotelid));
                result.Should().Be(true);
            };

            var SendInviteToBecomeManagerHOtelCommand2 = new InviteUserToJoinOrganizationCommand
            {
                businessesIds = HotelsIds2,
                Email = email,
                Roles = roles,
                Typeinvitation = TypeInvitation.hotel
            };

           
            await SendAsync(SendInviteToBecomeManagerHOtelCommand2);
            foreach (var hotelid in SendInviteToBecomeManagerHOtelCommand2.businessesIds)
            {
                var result2 = await GetHotelByIdUser(userid, Guid.Parse(hotelid));
                result2.Should().Be(true);
            };

            var SendInviteToBecomeManagerHOtelCommand2Duplicate = new InviteUserToJoinOrganizationCommand
            {
                businessesIds = HotelsIds2,
                Email = email,
                Roles = roles,
                Typeinvitation = TypeInvitation.hotel
            };


            await SendAsync(SendInviteToBecomeManagerHOtelCommand2Duplicate);
            foreach (var hotelid in SendInviteToBecomeManagerHOtelCommand2Duplicate.businessesIds)
            {
                var resultduplicate = await GetHotelByIdUser(userid, Guid.Parse(hotelid));
                resultduplicate.Should().Be(true);
            };





            var SendInviteToBecomeManagerFoodBusinessCommand3 = new InviteUserToJoinOrganizationCommand
            {
                businessesIds = foodIds,
                Email = email,
                Roles = roles,
                Typeinvitation = TypeInvitation.foodbusinness
            };


            await SendAsync(SendInviteToBecomeManagerFoodBusinessCommand3);
            foreach (var foodid in SendInviteToBecomeManagerFoodBusinessCommand3.businessesIds)
            {
                var result3 = await GetFoodByIdUser(userid, Guid.Parse(foodid));
                result3.Should().Be(true);
            }

            var SendInviteToBecomeManagerFoodBusinessCommandDuplicate = new InviteUserToJoinOrganizationCommand
            {
                businessesIds = foodIds,
                Email = email,
                Roles = roles,
                Typeinvitation = TypeInvitation.foodbusinness
            };


            await SendAsync(SendInviteToBecomeManagerFoodBusinessCommandDuplicate);
            foreach (var foodid in SendInviteToBecomeManagerFoodBusinessCommandDuplicate.businessesIds)
            {
                var result3 = await GetFoodByIdUser(userid, Guid.Parse(foodid));
                result3.Should().Be(true);
            }




            int TotalHotelsUser = GetAllHotelUserCount();
            TotalHotelsUser.Should().Be(3);
            int TotalFoodBusinessUser = GetAllFoodBusinessUserCount();
            TotalFoodBusinessUser.Should().Be(1);




        }
    }
}
