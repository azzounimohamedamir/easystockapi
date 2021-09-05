using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Users.Commands
{
    using static Testing;

    [TestFixture]
    public class SetNewPasswordForFoodBusinessAdministratorTest : TestBase
    {

        [Test]
        public async Task ShouldSetNewPasswordForFoodBusinessAdministrator()
        {
            // Real password is "Supportagent123@"
            var passwordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==";
            var foodBusinessAdministratorId = Guid.NewGuid().ToString();
            await RolesTestTools.CreateRoles();
            await CreateUserThenAssignRoleToHim(passwordHash, foodBusinessAdministratorId);

            var userBeforeSettingNewPassword = await FindIdentityAsync<ApplicationUser>(new[] { foodBusinessAdministratorId }).ConfigureAwait(false);
            Assert.AreEqual(userBeforeSettingNewPassword.PasswordHash, passwordHash);


            var setNewPasswordForFoodBusinessAdministratorCommand = new SetNewPasswordForFoodBusinessAdministratorCommand()
            {
                Id = foodBusinessAdministratorId,
                NewPassword = "15sd6suiAg"
            };
            await SendAsync(setNewPasswordForFoodBusinessAdministratorCommand);
            var userAfterSettingNewPassword = await FindIdentityAsync<ApplicationUser>(new[] { foodBusinessAdministratorId }).ConfigureAwait(false);
            Assert.AreNotEqual(userAfterSettingNewPassword.PasswordHash, passwordHash);
        }

        private static async Task CreateUserThenAssignRoleToHim(string passwordHash, string foodBusinessAdministratorId)
        {
            var user = new ApplicationUser()
            {
                Id = foodBusinessAdministratorId,
                FullName = "Aissa",
                Email = "FoodBusinessAdministrator@bv.com",
                UserName = "FoodBusinessAdministrator@bv.com",
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash = passwordHash
            };
            await AddIdentityAsync(user);
            var userRole = new ApplicationUserRole()
            {
                UserId = foodBusinessAdministratorId,
                RoleId = Convert.ToString((int)Roles.FoodBusinessAdministrator)
            };
            await AddIdentityAsync(userRole);
        }
    }
}