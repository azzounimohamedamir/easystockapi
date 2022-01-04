using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Commands
{
    using static Testing;

    [TestFixture]
    public class CalculateLastMonthCommissionFeesTest : TestBase
    {
        [Test]
        public async Task CalculateLastMonthCommissionFees_ShouldSaveToDB()
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
            var fastFoodWithCommissionSet = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);

            var now = DateTime.Now.AddMonths(-1);
            await SendAsync(new CalculateLastMonthCommissionFeesCommand());
            var monthlyCommission = Where<MonthlyCommission>(x => x.FoodBusinessId == fastFood.FoodBusinessId)[0];
                       
            monthlyCommission.FoodBusinessId.Should().Be(fastFoodWithCommissionSet.FoodBusinessId);
            monthlyCommission.Status.Should().Be(CommissionStatus.Unpaid);
            monthlyCommission.numberOfOrdersOrPersons.Should().Be(0);
            monthlyCommission.TotalToPay.Should().Be(0);
            monthlyCommission.Month.Should().Be(new DateTime(now.Year, now.Month, 1, 0, 0, 0));
            monthlyCommission.CommissionConfigs.Value.Should().Be(fastFoodWithCommissionSet.CommissionConfigs.Value);
            monthlyCommission.CommissionConfigs.Type.Should().Be(fastFoodWithCommissionSet.CommissionConfigs.Type);
            monthlyCommission.CommissionConfigs.WhoPay.Should().Be(fastFoodWithCommissionSet.CommissionConfigs.WhoPay);

        }
    }
}
