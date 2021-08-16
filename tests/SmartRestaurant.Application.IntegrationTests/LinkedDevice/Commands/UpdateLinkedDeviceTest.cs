using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.LinkedDevice.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.LinkedDevice.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateLinkedDeviceTest : TestBase
    {
        [Test]
        public async Task UpdatedReservation_ShouldBeSavedToDB()
        {

            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);

            var createFoodBusinessCommandSecond = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test2"
            };
            await SendAsync(createFoodBusinessCommandSecond);
            var fastFoodSecond = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommandSecond.Id);

            var createLinkDeviceIDCommand = new CreateLinkedDeviceCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                IdentifierDevice = "5SD-65F5-F5S-DF65SF-5SF6"
            };
            await SendAsync(createLinkDeviceIDCommand);
            var linkDevice = await FindAsync<Domain.Entities.LinkedDevice>(createLinkDeviceIDCommand.Id);

            Guid cmdId =  Guid.NewGuid();
            var updateLinkedDeviceCommand = new UpdateLinkedDeviceCommand
            {
                Id=linkDevice.LinkedDeviceId,
                FoodBusinessId = fastFoodSecond.FoodBusinessId,
                IdentifierDevice = "5SD-65F5-F5S-DF65SF-5SF6"
            };
            await SendAsync(updateLinkedDeviceCommand);
            var updatedLinkedDevice = await FindAsync<Domain.Entities.LinkedDevice>(updateLinkedDeviceCommand.Id);

            updatedLinkedDevice.Should().NotBeNull();
            updatedLinkedDevice.LinkedDeviceId.Should().Be(updateLinkedDeviceCommand.Id);
            updatedLinkedDevice.IdentifierDevice.Should().Equals(updateLinkedDeviceCommand.IdentifierDevice);
            updatedLinkedDevice.FoodBusinessId.Should().Be(updateLinkedDeviceCommand.FoodBusinessId);
        }
    }
}
