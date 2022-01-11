using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Queries
{
    using static Testing;

    public class GetCommissionConfigsListTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessList()
        {
            await RolesTestTools.CreateRoles();
            for (var i = 0; i < 5; i++)
            {
                var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
                var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id, "tacos Dz  " + i);
                var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
                {
                    FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                    Value = 25,
                    Type = CommissionType.PerPerson,
                    WhoPay = WhoPayCommission.FoodBusinessCustomer,
                };
                await SendAsync(setFoodBusinessCommissionCommand);
            }
            
            var result = await SendAsync(new GetFoodBusinessListQuery { Page = 1, PageSize = 5 });
            result.Data.Should().HaveCount(5);

            var result02 = await SendAsync(new GetFoodBusinessListQuery { Page = 1, PageSize = 5, SearchKey = "tacos Dz  1" });
            result02.Data.Should().HaveCount(1);

            var result03 = await SendAsync(new GetFoodBusinessListQuery { Page = 1, PageSize = 5, SearchKey = "tacos Dz  22" });
            result03.Data.Should().HaveCount(0);
        }
    }
}