using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Users.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateUserCommandTest : TestBase
    {

        [Test]
        public async Task ShouldUpdateUserAccount()
        {

            var userId = Guid.NewGuid().ToString();
            await RolesTestTools.CreateRoles();

            var user = await CreateUser(userId);
            await AssignRolesToUser(userId);


            var userBeforeUpdate = await FindIdentityAsync<ApplicationUser>(new[] { userId }).ConfigureAwait(false);
            var userHasSupportAgentRoleAfterUpdate = await FindIdentityAsync<ApplicationUserRole>(new[] { userId, Convert.ToString((int)Roles.SupportAgent) }).ConfigureAwait(false);

            Assert.AreEqual(userBeforeUpdate.Id, user.Id);
            Assert.AreEqual(userBeforeUpdate.FullName, user.FullName);
            Assert.AreEqual(userBeforeUpdate.PhoneNumber, user.PhoneNumber);
            Assert.IsNotNull(userHasSupportAgentRoleAfterUpdate);


            var updateUserCommand = new UpdateUserCommand
            {
                Id = userId,
                FullName = "bilal",
                PhoneNumber = "0888888888",
                Roles = new List<string>() { Roles.Photograph.ToString(), Roles.SalesMan.ToString() }
            };

            await SendAsync(updateUserCommand);

            var userAfterUpdate = await FindIdentityAsync<ApplicationUser>(new[] { userId }).ConfigureAwait(false);
            var userDoesNotHasSupportAgentRoleAfterUpdate = await FindIdentityAsync<ApplicationUserRole>(new[] { userId, Convert.ToString((int)Roles.SupportAgent) }).ConfigureAwait(false);
            var userHasPhotographRoleAfterUpdate = await FindIdentityAsync<ApplicationUserRole>(new[] { userId, Convert.ToString((int)Roles.Photograph)}).ConfigureAwait(false);
            var userHasSalesManRoleAfterUpdate = await FindIdentityAsync<ApplicationUserRole>(new[] { userId, Convert.ToString((int)Roles.SalesMan) }).ConfigureAwait(false);


            Assert.AreNotEqual(userAfterUpdate.FullName, user.FullName);
            Assert.AreNotEqual(userAfterUpdate.PhoneNumber, user.PhoneNumber);
            Assert.AreEqual(userAfterUpdate.Id, updateUserCommand.Id);
            Assert.AreEqual(userAfterUpdate.FullName, updateUserCommand.FullName);
            Assert.AreEqual(userAfterUpdate.PhoneNumber, updateUserCommand.PhoneNumber);
            Assert.IsNull(userDoesNotHasSupportAgentRoleAfterUpdate);
            Assert.IsNotNull(userHasPhotographRoleAfterUpdate);
            Assert.IsNotNull(userHasSalesManRoleAfterUpdate);
        }

        private static async Task AssignRolesToUser(string userId)
        {
            var userRole = new ApplicationUserRole()
            {
                UserId = userId,
                RoleId = Convert.ToString((int)Roles.SupportAgent)
            };
            await AddIdentityAsync(userRole);
        }

        private static async Task<ApplicationUser> CreateUser(string userId)
        {
            var user = new ApplicationUser()
            {
                Id = userId,
                FullName = "Aissa",
                Email = "FoodBusinessAdministrator@bv.com",
                UserName = "FoodBusinessAdministrator@bv.com",
                PhoneNumber = "077654656",
                IsActive = true,
                EmailConfirmed = true,
                // Real password is "Supportagent123@"
                PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);
            return user;
        }
    }
}