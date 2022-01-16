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

    public class GetMonthlyCommissionListBySmartRestaurantUserTest : TestBase
    {
        [Test]
        public async Task ShouldReturnMonthlyCommissionListBySmartRestauranUser()
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

            var result00 = await SendAsync(new GetMonthlyCommissionListBySmartRestaurantUserQuery
            {
                Page = 1,
                PageSize = 5,
                CurrentFilter = "foodbusinessname",
                SearchKey = "Taj mahal"
            });
            result00.Data.Should().HaveCount(1);


            var result01 = await SendAsync(new GetMonthlyCommissionListBySmartRestaurantUserQuery
            {
                Page = 1,
                PageSize = 5,
                CurrentFilter = "foodbusinessname",
                SearchKey = "Taj mahal m"
            });
            result01.Data.Should().HaveCount(0);


            var result02 = await SendAsync(new GetMonthlyCommissionListBySmartRestaurantUserQuery { 
                Page = 1, 
                PageSize = 5, 
                CurrentFilter = "foodbusinessadmin",
                SearchKey = "FoodBusinessAdministrator@bv.com" });
            result02.Data.Should().HaveCount(1);


            var result03 = await SendAsync(new GetMonthlyCommissionListBySmartRestaurantUserQuery { 
                Page = 1, 
                PageSize = 5,
                CurrentFilter = "foodbusinessadmin",
                SearchKey = "test@bv.com" });
            result03.Data.Should().HaveCount(0);


            var result04 = await SendAsync(new GetMonthlyCommissionListBySmartRestaurantUserQuery
            {
                Page = 1,
                PageSize = 5
            });
            result04.Data.Should().HaveCount(1);
        }
    }
}