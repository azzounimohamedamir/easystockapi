using netDumbster.smtp;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessUsers
{
    using static Testing;

    [TestFixture]
    public class InviteUserToJoinOrganizationTest : TestBase
    {
        private SimpleSmtpServer smtpServer;
        private SmtpConfig smtpConfig = new SmtpConfig
        {
            Email = "no-reply@fakesmtp.com",
            Pass = "",
            Server = "localhost",
            Port = 789
        };
        [SetUp]
        public void Setup()
        {
            smtpServer = SimpleSmtpServer.Start(smtpConfig.Port);
        }

        [TearDown]
        public void TearDown()
        {
            smtpServer.Stop();
            smtpServer.Dispose();
        }

        [Test]
        public async Task ShouldCreateUserAndSendInvitation()
        {
            var fastFood_01 = await FoodBusinessTestTools.CreateFoodBusiness();
            var fastFood_02 = await FoodBusinessTestTools.CreateFoodBusiness();
            await RolesTestTools.CreateRoles();

            var inviteUserToJoinOrganization = new InviteUserToJoinOrganizationCommand
            {
                Email = "aissa@gmail.com",
                FoodBusinessesIds = new List<string> { fastFood_01.FoodBusinessId.ToString(), fastFood_02.FoodBusinessId.ToString() },
                Roles = new List<string> { Roles.FoodBusinessManager.ToString() },
            };

            var invitationResult = await SendAsync(inviteUserToJoinOrganization);
            Assert.Null(invitationResult);

            var user = await FindIdentityAsync<ApplicationUser>(new[] { inviteUserToJoinOrganization.Id.ToString() }).ConfigureAwait(false);
            Assert.AreEqual(user.Id, inviteUserToJoinOrganization.Id.ToString());
            Assert.AreEqual(user.Email, inviteUserToJoinOrganization.Email);
            Assert.AreEqual(user.UserName, inviteUserToJoinOrganization.Email);
            Assert.IsTrue(user.EmailConfirmed);
            Assert.IsTrue(user.IsActive);

            //TODO find solution to check user roles
            //foreach (var role in inviteUserToJoinOrganization.Roles)
            //{
            //     var _role = await FindIdentityAsync<ApplicationUserRole>(new[] { "6", inviteUserToJoinOrganization.Id.ToString() }).ConfigureAwait(false);
            //     Assert.AreEqual(_role.UserId, inviteUserToJoinOrganization.Id.ToString());
            //     Assert.AreEqual(_role.RoleId, inviteUserToJoinOrganization.Email);
            //}

            foreach (var foodBusinessId in inviteUserToJoinOrganization.FoodBusinessesIds)
            {
                var foodBusinessUser =  Where<FoodBusinessUser>(x => x.FoodBusinessId == Guid.Parse(foodBusinessId));
                Assert.AreEqual(foodBusinessUser[0].ApplicationUserId, inviteUserToJoinOrganization.Id.ToString());
                Assert.AreEqual(foodBusinessUser[0].FoodBusinessId.ToString(), foodBusinessId);
            }                 

            Assert.AreEqual(1, smtpServer.ReceivedEmailCount);
            SmtpMessage mail = smtpServer.ReceivedEmail[0];
            Assert.AreEqual(inviteUserToJoinOrganization.Email, mail.Headers["To"]);
            Assert.AreEqual(smtpConfig.Email, mail.Headers["From"]);
            Assert.IsNotNull(mail.Headers["Subject"]);
            Assert.IsNotNull(mail.MessageParts[0].BodyData);
            Assert.IsNotEmpty(mail.Headers["Subject"]);
            Assert.IsNotEmpty(mail.MessageParts[0].BodyData);

        }
    }
}
