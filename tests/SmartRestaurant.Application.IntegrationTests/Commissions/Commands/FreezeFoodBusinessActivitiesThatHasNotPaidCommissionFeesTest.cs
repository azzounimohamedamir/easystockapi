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
    public class FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFeesTest : TestBase
    {
        [Test]
        public async Task FreezeFoodBusinessActivitiesThatHasNotPaidCommissionFees_FoodBusinessShouldBeFrozen()
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
        }
    }
}
