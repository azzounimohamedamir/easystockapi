using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Enums;

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
                    FourDigitCode = "0000"
                };

                await SendAsync(updateFourDigitCodeCommand);

                var item = await FindAsync<Domain.Entities.FoodBusiness>(foodBusinessCommand.Id);
                item.FourDigitCode.Should().NotBeNull();
                item.FourDigitCode.Equals("0000");
                item.FoodBusinessId.Should().Be(updateFourDigitCodeCommand.Id);
            });
        }
    }
}