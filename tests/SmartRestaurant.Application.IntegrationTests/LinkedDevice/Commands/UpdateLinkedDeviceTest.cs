using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.LinkedDevice.Commands;

namespace SmartRestaurant.Application.IntegrationTests.LinkedDevice.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateLinkedDeviceTest : TestBase
    {
        [Test]
        public async Task UpdatedReservation_ShouldBeSavedToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var fastFoodSecond = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createLinkDeviceIDCommand = new CreateLinkedDeviceCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                IdentifierDevice = "5SD-65F5-F5S-DF65SF-5SF6"
            };
            await SendAsync(createLinkDeviceIDCommand);
            var linkDevice = await FindAsync<Domain.Entities.LinkedDevice>(createLinkDeviceIDCommand.Id);

            var cmdId = Guid.NewGuid();
            var updateLinkedDeviceCommand = new UpdateLinkedDeviceCommand
            {
                Id = linkDevice.LinkedDeviceId,
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