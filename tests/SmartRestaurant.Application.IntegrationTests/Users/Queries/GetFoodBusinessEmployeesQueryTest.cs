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
    public class GetFoodBusinessEmployeesQueryTest : TestBase
    {
        [Test]
        public async Task ShouldGetFoodBusinessManagers()
        {
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness();
            await RolesTestTools.CreateRoles();

            var foodBusinessAdministrator = await CreateFoodBusinessAdministratorUser();
            await AssignRolesToFoodBusinessAdministrator(foodBusinessAdministrator);

            var foodBusinessManager = await CreateFoodBusinessManagerUser();
            await AssignRolesToFoodBusinessManager(foodBusinessManager);
            await AssignFoodBusinessManagerToOrganisation(foodBusinessManager, fastFood);


            var query = new GetFoodBusinessEmployeesQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                Page = 1,
                PageSize = 10
            };
            var result = await SendAsync(query);
            result.Data.Should().HaveCount(1);
            result.Data[0].Id.Should().Be(foodBusinessManager.Id);
            result.Data[0].Roles.Should().NotBeNull();
        }

        private static async Task AssignRolesToFoodBusinessAdministrator(ApplicationUser user)
        {
            var userRoles = new ApplicationUserRole
            {
                RoleId = ((int)Roles.FoodBusinessAdministrator).ToString(),
                UserId = user.Id
            };
            await AddIdentityAsync(userRoles);
        }

        private static async Task AssignRolesToFoodBusinessManager(ApplicationUser user)
        {
            var userRoles = new ApplicationUserRole
            {
                RoleId = ((int)Roles.FoodBusinessManager).ToString(),
                UserId = user.Id
            };
            await AddIdentityAsync(userRoles);
        }

        private static async Task AssignFoodBusinessManagerToOrganisation(ApplicationUser user, Domain.Entities.FoodBusiness foodBusiness)
        {
            var foodBusinessUser = new FoodBusinessUser
            {
               ApplicationUserId = user.Id,             
               FoodBusinessId = foodBusiness.FoodBusinessId
            };
            await AddAsync(foodBusinessUser);
        }

        private static async Task<ApplicationUser> CreateFoodBusinessAdministratorUser()
        {
            var user = new ApplicationUser("FoodBusinessAdministrator", "FoodBusinessAdministrator@bv.com", "FoodBusinessAdministrator@bv.com")
            {
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash =  // Real password is "Supportagent123@"
                                    "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
            };
            await AddIdentityAsync(user);
            return user;
        }

        private static async Task<ApplicationUser> CreateFoodBusinessManagerUser()
        {
            var user = new ApplicationUser("FoodBusinessManager", "FoodBusinessManager@bv.com", "FoodBusinessManager@bv.com")
            {
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash =  // Real password is "Supportagent123@"
                                    "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
            };
            await AddIdentityAsync(user);
            return user;
        }
    }
}