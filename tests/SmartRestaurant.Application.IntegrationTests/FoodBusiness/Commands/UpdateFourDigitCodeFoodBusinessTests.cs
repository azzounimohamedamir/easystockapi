using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateFourDigitCodeFoodBusinessTests : TestBase
    {
        [Test]
        public async Task UpdateFourDigitCode_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFourDigitCodeCommand = new UpdateFourDigitCodeCommand
                {
                    Id = fastFood.FoodBusinessId,
                    FourDigitCode = 5555
                };
                await SendAsync(updateFourDigitCodeCommand);

                var item = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
                item.FourDigitCode.IsSameOrEqualTo(5555);
                item.FoodBusinessId.Should().Be(updateFourDigitCodeCommand.Id);
            });
        }
    }
}