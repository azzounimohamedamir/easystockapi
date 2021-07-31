using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteFoodBusinessTests : TestBase
    {
        [Test]
        public async Task DeleteFoodBusinessTask()
        {
            var createCommand = new CreateFoodBusinessCommand
            {
                Name = "Taj mahal",
                Id = Guid.NewGuid(),
                FoodBusinessAdministratorId = "4"
            };
            await SendAsync(createCommand);

            await SendAsync(new DeleteFoodBusinessCommand
            {
                Id = createCommand.Id
            });

            var foodBusiness = await FindAsync<Domain.Entities.FoodBusiness>(createCommand.Id);
            foodBusiness.Should().BeNull();
        }
    }
}