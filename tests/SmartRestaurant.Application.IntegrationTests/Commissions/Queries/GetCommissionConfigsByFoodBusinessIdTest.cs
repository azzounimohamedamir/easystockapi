using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.commisiones.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Commissions.Queries
{
    using static Testing;

    [TestFixture]
    public class GetCommissionConfigsByFoodBusinessIdTest : TestBase
    {
        [Test]
        public async Task GetCommissionConfigsByFoodBusinessId_ShouldReturnCommissionConfigs()
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

            var commissionConfigs = await SendAsync(new GetCommissionConfigsByFoodBusinessIdQuery { 
                FoodBusinessId = fastFood.FoodBusinessId.ToString() });

                       
            commissionConfigs.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            commissionConfigs.DefaultCurrency.Should().Be(fastFood.DefaultCurrency);
            commissionConfigs.Value.Should().Be(setFoodBusinessCommissionCommand.Value);
            commissionConfigs.Type.Should().Be(setFoodBusinessCommissionCommand.Type);
            commissionConfigs.WhoPay.Should().Be(setFoodBusinessCommissionCommand.WhoPay);

        }
    }
}
