using FluentValidation.TestHelper;
using SmartRestaurant.Application.LinkedDevice.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.LinkedDevice
{
   public class UpdateLinkDeviceCommandValidatorTest
    {
        private readonly UpdateLinkedDeviceommandValidator _validator;

        public UpdateLinkDeviceCommandValidatorTest()
        {
            _validator = new UpdateLinkedDeviceommandValidator();
        }

        [Fact]
        public void Given_IdentifierDevice_WhenValidating_ShouldBeValidated()
        {
            string validIdentifierDevice = "5SD-65F5-F5S-DF65SF-5SF6";
            _validator.ShouldNotHaveValidationErrorFor(R => R.IdentifierDevice, validIdentifierDevice);
        }



        [Fact]
        public void Given_FoodBusinessId_WhenValidating_ShouldBeValidated()
        {
            var empty = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(foodBusiness=> foodBusiness.FoodBusinessId, empty);
        }

    }
}
