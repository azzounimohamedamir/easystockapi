using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.CommissionsMonthlyFees.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Commands
{
    using static Testing;

    [TestFixture]
    public class PayFoodBusinessMonthlyCommissionFeesTest : TestBase
    {
        [Test]
        public async Task PayFoodBusinessMonthlyCommissionFeesTest_MonthlyCommissionShouldBePaid()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            fastFood.IsActivityFrozen.Should().BeFalse();

            var setFoodBusinessCommissionCommand = new SetFoodBusinessCommissionCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                Value = 25,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusinessCustomer,
            };

            await SendAsync(setFoodBusinessCommissionCommand);
            await SendAsync(new CalculateLastMonthCommissionFeesCommand());
            var fastFoodWithCommissionSetAndCalculated = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            fastFoodWithCommissionSetAndCalculated.IsActivityFrozen.Should().BeFalse();

            await SendAsync(new FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFeesCommand());
            var fastFoodAfterGettingFreeze = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            fastFoodAfterGettingFreeze.IsActivityFrozen.Should().BeTrue();
            var monthlyCommissionBeforPayment = Where<Domain.Entities.MonthlyCommission>(x => x.FoodBusinessId == fastFood.FoodBusinessId)[0];
            monthlyCommissionBeforPayment.Status.Should().Be(CommissionStatus.Unpaid);


            await SendAsync(new PayFoodBusinessMonthlyCommissionFeesCommand { MonthlyCommissionId = monthlyCommissionBeforPayment.MonthlyCommissionId.ToString() });
            var fastFoodAfterPayment= await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            fastFoodAfterPayment.IsActivityFrozen.Should().BeFalse();
            var monthlyCommissionAfterPayment = Where<Domain.Entities.MonthlyCommission>(x => x.FoodBusinessId == fastFood.FoodBusinessId)[0];
            monthlyCommissionAfterPayment.Status.Should().Be(CommissionStatus.Paid);
        }
    }
}
