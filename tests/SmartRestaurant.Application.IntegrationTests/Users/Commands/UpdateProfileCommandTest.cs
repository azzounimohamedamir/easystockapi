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
    public class UpdateProfileCommandTest : TestBase
    {

        [Test]
        public async Task ShouldUpdateProfileAccount()
        {

            var userId = _authenticatedUserId;
            await RolesTestTools.CreateRoles();

            var user = await CreateUser(userId);
            await AssignRolesToUser(userId);


            var userBeforeUpdate = await FindIdentityAsync<ApplicationUser>(new[] { userId }).ConfigureAwait(false);

            Assert.AreEqual(userBeforeUpdate.Id, user.Id);


            var profileUpdateCommand = new UpdateProfileCommand
            {
                FullName = "bilal",
                PhoneNumber = "0888888888"
            };

            await SendAsync(profileUpdateCommand);

            var userAfterUpdate = await FindIdentityAsync<ApplicationUser>(new[] { userId }).ConfigureAwait(false);

            Assert.AreNotEqual(userAfterUpdate.FullName, userBeforeUpdate.FullName);
            Assert.AreNotEqual(userAfterUpdate.PhoneNumber, userBeforeUpdate.PhoneNumber);
            Assert.AreEqual(userAfterUpdate.Id, userId);
            Assert.AreEqual(userAfterUpdate.FullName, profileUpdateCommand.FullName);
            Assert.AreEqual(userAfterUpdate.PhoneNumber, profileUpdateCommand.PhoneNumber);
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