using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Users.Queries
{
	using static Testing;

	[TestFixture]
	public class GetUsersByRoleQueryTest : TestBase
	{
		[Test]
		public async Task ShouldGetListOfUsers()
		{
			var userId = Guid.NewGuid().ToString();
			await RolesTestTools.CreateRoles();
			var user = await CreateUser(userId);
			await AssignRolesToUser(userId);

			var query = new GetUsersByRoleQuery
			{
				Role = Roles.SupportAgent.ToString(),
				Page = 1,
				PageSize = 10
			};
			var result = await SendAsync(query);
			result.Data.Should().HaveCount(1);
			result.Data[0].Id.Should().Be(user.Id);
			result.Data[0].Email.Should().Be(user.Email);
			result.Data[0].FullName.Should().Be(user.FullName);
			result.Data[0].PhoneNumber.Should().Be(user.PhoneNumber);
			result.Data[0].UserName.Should().Be(user.UserName);
			result.Data[0].IsActive.Should().Be(user.IsActive);
			result.Data[0].Roles.Should().Contain(Roles.SupportAgent.ToString());
			result.Data[0].Roles.Should().Contain(Roles.SalesMan.ToString());
		}

		private static async Task AssignRolesToUser(string userId)
		{
			var userRole1 = new ApplicationUserRole()
			{
				UserId = userId,
				RoleId = Convert.ToString((int)Roles.SupportAgent)
			};
			await AddIdentityAsync(userRole1);

			var userRole2 = new ApplicationUserRole()
			{
				UserId = userId,
				RoleId = Convert.ToString((int)Roles.SalesMan)
			};
			await AddIdentityAsync(userRole2);
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
				IsShowPhoneNumberInOdoo=true,
				// Real password is "Supportagent123@"
				PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
			};
			await AddIdentityAsync(user);
			return user;
		}
	}
}