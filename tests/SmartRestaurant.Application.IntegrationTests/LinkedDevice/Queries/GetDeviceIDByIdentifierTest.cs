using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.LinkedDevice.Queries;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Reservations.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.DeviceID.Queries
{
    using static Testing;

    [TestFixture]
    public class GetDeviceIDByIdentifierTest : TestBase
    {
        [Test]
        public async Task ShouldGetReservation_ById()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);

            var createDeviceIDCommand = new CreateLinkedDeviceCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                IdentifierDevice = "6FGD-FFFD-6FS4DF-5S4F-6S4F"
            };
            var validationResult = await SendAsync(createDeviceIDCommand);
            var item = await FindAsync<Domain.Entities.LinkedDevice>(createDeviceIDCommand.Id);

            var query = new GetLinkedDeviceByIdQuery { IdentifierDevice = createDeviceIDCommand.IdentifierDevice};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.IdentifierDevice.Should().Be("6FGD-FFFD-6FS4DF-5S4F-6S4F");
        }
    }
}
