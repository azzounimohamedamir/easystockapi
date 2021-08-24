using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateFourDigitCodeFoodBusinessTests : TestBase
    {
        [Test]
        public async Task UpdateFourDigitCode_ShouldSaveToDB()
        {
            var foodBusinessCommand = new CreateFoodBusinessCommand
            {
                Name = "Fast Food Test",
                AverageRating = 10,
                HasCarParking = true,
                FoodBusinessAdministratorId = "7"
            };

            await SendAsync(foodBusinessCommand);
            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFourDigitCodeCommand = new UpdateFourDigitCodeCommand
                {
                    Id = foodBusinessCommand.Id,
                    FourDigitCode = 0000
                };

                await SendAsync(updateFourDigitCodeCommand);

                var item = await FindAsync<Domain.Entities.FoodBusiness>(foodBusinessCommand.Id);
                item.FourDigitCode.IsSameOrEqualTo(0000);
                item.FoodBusinessId.Should().Be(updateFourDigitCodeCommand.Id);
            });
        }
    }
}