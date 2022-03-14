using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.LinkedDevice.Queries;

namespace SmartRestaurant.Application.IntegrationTests.LinkedDevice.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateLinkedDeviceTest : TestBase
    {
        [Test]
        public async Task CreateDeviceID_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createDeviceIDCommand = new CreateLinkedDeviceCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                IdentifierDevice = "5SD-65F5-F5S-DF65SF-5SF6"
            };
            var validationResult = await SendAsync(createDeviceIDCommand);
            var item = await FindAsync<Domain.Entities.LinkedDevice>(createDeviceIDCommand.Id);

            var query = new GetLinkedDeviceByIdQuery {IdentifierDevice = createDeviceIDCommand.IdentifierDevice};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.IdentifierDevice.Should().Be("5SD-65F5-F5S-DF65SF-5SF6");
        }
    }
}