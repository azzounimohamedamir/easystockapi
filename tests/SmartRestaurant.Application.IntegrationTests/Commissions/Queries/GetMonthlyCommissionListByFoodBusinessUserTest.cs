using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.CommissionsMonthlyFees.Commands;
using SmartRestaurant.Application.CommissionsMonthlyFees.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Queries
{
    using static Testing;

    public class GetMonthlyCommissionListByFoodBusinessUserTest : TestBase
    {
        [Test]
        public async Task ShouldReturnMonthlyCommissionListByFoodBusinessUser()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
                {
                    FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                    Value = 25,
                    Type = CommissionType.PerPerson,
                    WhoPay = WhoPayCommission.FoodBusinessCustomer,
                };
                await SendAsync(setFoodBusinessCommissionCommand);
                await SendAsync(new CalculateLastMonthCommissionFeesCommand());

            var result02 = await SendAsync(new GetMonthlyCommissionListByFoodBusinessUserQuery { Page = 1, PageSize = 5, FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            result02.Data.Should().HaveCount(1);

            var result03 = await SendAsync(new GetMonthlyCommissionListByFoodBusinessUserQuery { Page = 1, PageSize = 5, FoodBusinessId = Guid.NewGuid().ToString() });
            result03.Data.Should().HaveCount(0);
        }
    }
}