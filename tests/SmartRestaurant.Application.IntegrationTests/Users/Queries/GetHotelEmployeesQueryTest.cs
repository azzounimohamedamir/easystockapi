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
    public class GetHotelEmployeesQueryTest : TestBase
    {
        [Test]
        public async Task ShouldGetHotelEmployess()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id,"safir") ;

            var SafirManager = await CreateHotelManagerUser();
            await AssignRolesToHotelManager(SafirManager);
            await AssignHotelManagerToOrganisation(SafirManager, hotelsafir);


            var query = new GetHotelEmployeesQuery
            {
                HotelId = hotelsafir.Id.ToString(),
                Page = 1,
                PageSize = 10
            };
            var result = await SendAsync(query);
            result.Data.Should().HaveCount(1);
            result.Data[0].Id.Should().Be(SafirManager.Id);
            result.Data[0].Roles.Should().NotBeNull();
        }

       

        private static async Task AssignRolesToHotelManager(ApplicationUser user)
        {
            var userRoles = new ApplicationUserRole
            {
                RoleId = ((int)Roles.HotelReceptionist).ToString(),
                UserId = user.Id
            };
            await AddIdentityAsync(userRoles);
        }

        private static async Task AssignHotelManagerToOrganisation(ApplicationUser user,
            Domain.Entities.Hotel hotel)
        {
            var hotelUser = new HotelUser
            {
                ApplicationUserId = user.Id,
                HotelId = hotel.Id
            };
            await AddAsync(hotelUser);
        }

        private static async Task<ApplicationUser> CreateHotelManagerUser()
        {
            var user = new ApplicationUser("cccccccccc", "rccccc@bv.com",
                "ggggghghcggom")
            {
                IsActive = true,
                EmailConfirmed = true,
                PasswordHash = // Real password is "Supportagent123@"
                    "AQAAAAEAACcQAffAffffffffffffffffffAAEE2YnfffffCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);
            return user;
        }
    }
}