using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class ToggleFoodBusinessFreezingStatusTests : TestBase
    {
        [Test]
        public async Task ToggleFoodBusinessFreezingStatusTask()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var foodBusinessBeforeTogglingFreezingStatus = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            foodBusinessBeforeTogglingFreezingStatus.IsActivityFrozen.Should().BeFalse();

            await SendAsync(new ToggleFoodBusinessFreezingStatusCommand { FoodBusinessId = fastFood.FoodBusinessId.ToString()});
            var foodBusinessAfterTogglingFreezingStatus = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            foodBusinessAfterTogglingFreezingStatus.IsActivityFrozen.Should().BeTrue();

        }
    }
}