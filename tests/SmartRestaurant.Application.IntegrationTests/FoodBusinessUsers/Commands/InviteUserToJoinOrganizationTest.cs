using System.Threading.Tasks;
using netDumbster.smtp;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusinessUsers.Commands
{
    [TestFixture]
    public class InviteUserToJoinOrganizationTest : TestBase
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

        private readonly SmtpConfig smtpConfig = new SmtpConfig
        {
            Email = "no-reply@fakesmtp.com",
            Pass = "",
            Server = "localhost",
            Port = 789
        };

        [Test]
        public async Task ShouldCreateUserAndSendInvitation()
        {
            //var fastFood_01 = await FoodBusinessTestTools.CreateFoodBusiness();
            //var fastFood_02 = await FoodBusinessTestTools.CreateFoodBusiness();
            //await RolesTestTools.CreateRoles();

            //var inviteUserToJoinOrganization = new InviteUserToJoinOrganizationCommand
            //{
            //    Email = "aissa@gmail.com",
            //    FoodBusinessesIds = new List<string> { fastFood_01.FoodBusinessId.ToString(), fastFood_02.FoodBusinessId.ToString() },
            //    Roles = new List<string> { Roles.FoodBusinessManager.ToString() },
            //};

            //var invitationResult = await SendAsync(inviteUserToJoinOrganization);
            //Assert.Null(invitationResult);

            //var user = await FindIdentityAsync<ApplicationUser>(new[] { inviteUserToJoinOrganization.Id.ToString() }).ConfigureAwait(false);
            //Assert.AreEqual(user.Id, inviteUserToJoinOrganization.Id.ToString());
            //Assert.AreEqual(user.Email, inviteUserToJoinOrganization.Email);
            //Assert.AreEqual(user.UserName, inviteUserToJoinOrganization.Email);
            //Assert.IsTrue(user.EmailConfirmed);
            //Assert.IsTrue(user.IsActive);

            ////TODO find solution to check user roles
            ////foreach (var role in inviteUserToJoinOrganization.Roles)
            ////{
            ////     var _role = await FindIdentityAsync<ApplicationUserRole>(new[] { "6", inviteUserToJoinOrganization.Id.ToString() }).ConfigureAwait(false);
            ////     Assert.AreEqual(_role.UserId, inviteUserToJoinOrganization.Id.ToString());
            ////     Assert.AreEqual(_role.RoleId, inviteUserToJoinOrganization.Email);
            ////}

            //foreach (var foodBusinessId in inviteUserToJoinOrganization.FoodBusinessesIds)
            //{
            //    var foodBusinessUser =  Where<FoodBusinessUser>(x => x.FoodBusinessId == Guid.Parse(foodBusinessId));
            //    Assert.AreEqual(foodBusinessUser[0].ApplicationUserId, inviteUserToJoinOrganization.Id.ToString());
            //    Assert.AreEqual(foodBusinessUser[0].FoodBusinessId.ToString(), foodBusinessId);
            //}                 

            //Assert.AreEqual(1, smtpServer.ReceivedEmailCount);
            //SmtpMessage mail = smtpServer.ReceivedEmail[0];
            //Assert.AreEqual(inviteUserToJoinOrganization.Email, mail.Headers["To"]);
            //Assert.AreEqual(smtpConfig.Email, mail.Headers["From"]);
            //Assert.IsNotNull(mail.Headers["Subject"]);
            //Assert.IsNotNull(mail.MessageParts[0].BodyData);
            //Assert.IsNotEmpty(mail.Headers["Subject"]);
            //Assert.IsNotEmpty(mail.MessageParts[0].BodyData);
        }
    }
}