using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using netDumbster.smtp;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Domain.Identity.Enums;
using SmartRestaurant.Infrastructure.Email;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessUsers.Commands
{
    [TestFixture]
    public class UserAcceptsInvitationToJoinOrganizationTest : TestBase
    {
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

        private SimpleSmtpServer smtpServer;
        private readonly HtmlDocument doc = new HtmlDocument();

        private readonly SmtpConfig smtpConfig = new SmtpConfig
        {
            Email = "no-reply@fakesmtp.com",
            Pass = "",
            Server = "localhost",
            Port = 789
        };

        [Test]
        public async Task ShouldUpdateUserInfoAndResetPassword()
        {
            //await RolesTestTools.CreateRoles();
            //var fastFood_01 = await FoodBusinessTestTools.CreateFoodBusiness();
            //var fastFood_02 = await FoodBusinessTestTools.CreateFoodBusiness();

            //var inviteUserToJoinOrganization = CreateInvitationCommand(fastFood_01, fastFood_02);
            //var invitationResult = await SendAsync(inviteUserToJoinOrganization);
            //Assert.Null(invitationResult);

            //var user = await FindIdentityAsync<ApplicationUser>(new[] { inviteUserToJoinOrganization.Id.ToString() }).ConfigureAwait(false);
            //Assert.AreEqual(user.Id, inviteUserToJoinOrganization.Id.ToString());
            //Assert.AreEqual(user.Email, inviteUserToJoinOrganization.Email);
            //Assert.AreEqual(user.UserName, inviteUserToJoinOrganization.Email);
            //Assert.IsTrue(user.EmailConfirmed);
            //Assert.IsTrue(user.IsActive);

            //Assert.AreEqual(1, smtpServer.ReceivedEmailCount);
            //SmtpMessage mail = smtpServer.ReceivedEmail[0];

            //var userAcceptsInvitationToJoinOrganizationCommand = UserAcceptsInvitationCommand(mail);
            //var invitationAcceptedResult = await SendAsync(userAcceptsInvitationToJoinOrganizationCommand);
            //Assert.Null(invitationAcceptedResult);

            //var updatedUser = await FindIdentityAsync<ApplicationUser>(new[] { user.Id }).ConfigureAwait(false);
            //Assert.AreEqual(updatedUser.Id, user.Id);
            //Assert.AreEqual(updatedUser.Email, user.Email);
            //Assert.AreEqual(updatedUser.UserName, user.UserName);
            //Assert.AreEqual(updatedUser.FullName, userAcceptsInvitationToJoinOrganizationCommand.FullName);
            //Assert.AreEqual(updatedUser.PhoneNumber, userAcceptsInvitationToJoinOrganizationCommand.PhoneNumber);
            //Assert.AreNotEqual(updatedUser.PasswordHash, user.PasswordHash);
            //Assert.IsTrue(user.EmailConfirmed);
            //Assert.IsTrue(user.IsActive);
        }

        private UserAcceptsInvitationToJoinOrganizationCommand UserAcceptsInvitationCommand(SmtpMessage mail)
        {
            return new UserAcceptsInvitationToJoinOrganizationCommand
            {
                Id = ExtractUserIdFromHtmlPage(mail.MessageParts[0].BodyData),
                Email = "aissa@gmail.COM",
                FullName = "aissa",
                Password = "12345678",
                PhoneNumber = "+213778865789",
                Token = ExtractTokenFromHtmlPage(mail.MessageParts[0].BodyData)
            };
        }

        private InviteUserToJoinOrganizationCommand CreateInvitationCommand(Domain.Entities.FoodBusiness fastFood_01,
            Domain.Entities.FoodBusiness fastFood_02)
        {
            return new InviteUserToJoinOrganizationCommand
            {
                Email = "aissa@gmail.com",
                businessesIds = new List<string>
                    {fastFood_01.FoodBusinessId.ToString(), fastFood_02.FoodBusinessId.ToString()},
                Roles = new List<string> {Roles.FoodBusinessManager.ToString()}
            };
        }

        private string ExtractTokenFromHtmlPage(string htmlContent)
        {
            doc.LoadHtml(htmlContent);
            var html = new List<string>();
            foreach (var node in doc.DocumentNode.SelectNodes("//text()")) html.Add(node.InnerText);
            return html[5].Substring(2);
        }

        private string ExtractUserIdFromHtmlPage(string htmlContent)
        {
            doc.LoadHtml(htmlContent);
            var html = new List<string>();
            foreach (var node in doc.DocumentNode.SelectNodes("//a[@href]")) html.Add(node.Attributes["href"].Value);
            return Regex.Match(html[0],
                    @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}")
                .Value;
        }
    }
}