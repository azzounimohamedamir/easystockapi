using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteFoodBusinessTests : TestBase
    {
        [Test]
        public async Task DeleteFoodBusinessTask()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();

            var createCommand = new CreateFoodBusinessCommand
            {
                Name = "Taj mahal",
                FoodBusinessAdministratorId = foodBusinessAdministrator.Id
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