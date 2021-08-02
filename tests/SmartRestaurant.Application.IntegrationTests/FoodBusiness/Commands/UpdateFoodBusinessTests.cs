using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    public class UpdateFoodBusinessTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateFoodBusiness()
        {
            var foodBusinessCommand = new CreateFoodBusinessCommand
            {
                Name = "Taj mahal",
                AverageRating = 12,
                HasCarParking = true,
                FoodBusinessAdministratorId = "4"
            };

            await SendAsync(foodBusinessCommand);

            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFoodBusinessCommand = new UpdateFoodBusinessCommand
                {
                    Id = foodBusinessCommand.Id,
                    Name = "Taj mahal Updated test"
                };

                await SendAsync(updateFoodBusinessCommand);

                var list = await FindAsync<Domain.Entities.FoodBusiness>(foodBusinessCommand.Id);


                list.FoodBusinessId.Should().Be(updateFoodBusinessCommand.Id);
            });
        }
    }
}