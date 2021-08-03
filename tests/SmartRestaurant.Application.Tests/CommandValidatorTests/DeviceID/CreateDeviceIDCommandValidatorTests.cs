using FluentValidation.TestHelper;
using SmartRestaurant.Application.DeviceID.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.DeviceID
{
    public class CreateDeviceIDCommandValidatorTests
    {
        private readonly CreateDeviceIDCommandValidator _validator;

        public CreateDeviceIDCommandValidatorTests()
        {
            _validator = new CreateDeviceIDCommandValidator();
        }

        [Fact]
        public void Given_Empty_identifierDeviceID_WhenValidating_ShouldError()
        {
            var incorrectIdentifier = string.Empty;
            _validator.ShouldHaveValidationErrorFor(DeviceID => DeviceID.IdentifierDevice, incorrectIdentifier);
        }


        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(DeviceID => DeviceID.FoodBusinessId, emptyGuid);
        }
    }
}
