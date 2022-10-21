using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Users.Queries
{
    using static Testing;

    [TestFixture]
    public class GetHotelManagersWithinOrganizationQueryTest : TestBase
    {
        [Test]
        public async Task ShouldGetHotelManagers()
        {
            await RolesTestTools.CreateRoles();
            var organization_01_foodBusinessAdministrator = await CreateFoodBusinessAdministratorUser(_authenticatedUserId);
            await AssignRolesToFoodBusinessAdministrator(organization_01_foodBusinessAdministrator);
            var organization_01_hotel_01 = await HotelTestTools.CreateHotel(_authenticatedUserId,"IBIS HOTE");
            var organization_01_hotel_02 = await HotelTestTools.CreateHotel(_authenticatedUserId,"AURASSI HOTEL");



            var organization_01_hotelManager = await CreatehotelManagerUser();
            await AssignRolesToFoodBusinessManager(organization_01_hotelManager);
            await AssignFoodBusinessManagerToOrganisation(organization_01_hotelManager, organization_01_hotel_01);

            var organization_01_hotelManager_02 = await CreatehotelManagerUser();
            await AssignRolesToFoodBusinessManager(organization_01_hotelManager_02);
            await AssignFoodBusinessManagerToOrganisation(organization_01_hotelManager_02, organization_01_hotel_02);

            var organization_01_hotelManager_03 = await CreatehotelManagerUser();
            await AssignRolesToFoodBusinessManager(organization_01_hotelManager_03);
            await AssignFoodBusinessManagerToOrganisation(organization_01_hotelManager_03, organization_01_hotel_02);

            var organization_02_foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var organization_02_hotel = await HotelTestTools.CreateHotel(organization_02_foodBusinessAdministrator.Id,"TULIP HOTEL");


            var organization_02_hotelManager = await CreatehotelManagerUser();
            await AssignRolesToFoodBusinessManager(organization_02_hotelManager);
            await AssignFoodBusinessManagerToOrganisation(organization_02_hotelManager, organization_02_hotel);


            var query = new GetHotelsManagersWithinOrganizationQuery
            {
                Page = 1,
                PageSize = 10
            };
            var result = await SendAsync(query);
            result.Data.Should().HaveCount(3);
            result.Data[0].Roles.Should().Contain(Roles.FoodBusinessManager.ToString());
            result.Data[1].Roles.Should().Contain(Roles.FoodBusinessManager.ToString());
            result.Data[2].Roles.Should().Contain(Roles.FoodBusinessManager.ToString());
        }

        private static async Task AssignRolesToFoodBusinessAdministrator(ApplicationUser user)
        {
            var userRoles = new ApplicationUserRole
            {
                RoleId = ((int) Roles.FoodBusinessAdministrator).ToString(),
                UserId = user.Id
            };
            await AddIdentityAsync(userRoles);
        }

        private static async Task AssignRolesToFoodBusinessManager(ApplicationUser user)
        {
            var userRoles = new ApplicationUserRole
            {
                RoleId = ((int) Roles.FoodBusinessManager).ToString(),
                UserId = user.Id
            };
            await AddIdentityAsync(userRoles);
        }

        private static async Task AssignFoodBusinessManagerToOrganisation(ApplicationUser user,
            Domain.Entities.Hotel hotel)
        {
            var hotelUser = new HotelUser
            {
                ApplicationUserId = user.Id,
                HotelId = hotel.Id
            };
            await AddAsync(hotelUser);
        }

        private static async Task<ApplicationUser> CreateFoodBusinessAdministratorUser(
            string foodBusinessAdministratorId)
        {
            var randomNumber = new Random().Next(100, 200);

            var user = new ApplicationUser(
                randomNumber + "FoodBusinessAdministrator",
                randomNumber + "FoodBusinessAdministrator@bv.com",
                randomNumber + "FoodBusinessAdministrator@bv.com")
            {
                Id = foodBusinessAdministratorId,
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash = // Real password is "Supportagent123@"
                    "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);
            return user;
        }

        private static async Task<ApplicationUser> CreatehotelManagerUser()
        {
            var randomNumber = new Random().Next(100, 200);

            var user = new ApplicationUser(
                randomNumber + "FoodBusinessManager",
                randomNumber + "FoodBusinessManager@bv.com",
                randomNumber + "FoodBusinessManager@bv.com")
            {
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash = // Real password is "Supportagent123@"
                    "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);
            return user;
        }
    }
}