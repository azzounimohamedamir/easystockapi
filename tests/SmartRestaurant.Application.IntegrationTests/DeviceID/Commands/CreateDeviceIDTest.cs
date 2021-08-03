using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.DeviceID.Commands;
using SmartRestaurant.Application.FoodBusiness.Commands;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.DeviceID.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateDeviceIDTest
    {
        [Test]
        public async Task CreateDeviceID_ShouldSaveToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);

            var createDeviceIDCommand = new CreateDeviceIDCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                IdentifierDevice= "5SD65F5F5SDF65SF5SF6"
            };
            var validationResult = await SendAsync(createDeviceIDCommand);
            var item = await FindAsync<Domain.Entities.DeviceID>(createDeviceIDCommand.CmdId); 
          
            validationResult.Should().Be(default(ValidationResult));
            fastFood.Should().NotBeNull();
            item.Should().NotBeNull();
            item.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            item.IdentifierDevice.Should().Be(createDeviceIDCommand.IdentifierDevice);
        }
    }
}
