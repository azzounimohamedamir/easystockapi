using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using System;
using System.Threading.Tasks;

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
                NameEnglish = "Taj mahal",
                CmdId = Guid.NewGuid(),
                FoodBusinessAdministratorId = "4"
            };
            await SendAsync(createCommand);
            await SendAsync(new DeleteFoodBusinessCommand
            {
                FoodBusinessId = createCommand.CmdId

            });

            var foodBusiness = await FindAsync<Domain.Entities.FoodBusiness>(createCommand.CmdId);
            foodBusiness.Should().BeNull();
        }
    }
}
