using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusiness
{
    public class  UpdateFourDigitCodeCommandValidatorTests
    {
        private readonly UpdateFourDigitCodeCommandValidator _validator;

        public UpdateFourDigitCodeCommandValidatorTests()
        {
            _validator = new UpdateFourDigitCodeCommandValidator();
        }

        [Fact]
        public void Given_LengthFourDigitCode_lessThan_4_WhenValidating_ShouldError()
        {
            var FourDigitCodeMinLength = 000;
            _validator.ShouldHaveValidationErrorFor(R => R.FourDigitCode, FourDigitCodeMinLength);
        }

       

    }
}