using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusiness
{
    public class UpdateFoodBusinessCommandValidatorTests
    {
        private readonly UpdateFoodBusinessCommandValidator _validator;

        public UpdateFoodBusinessCommandValidatorTests()
        {
            _validator = new UpdateFoodBusinessCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldNotHaveError()
        {
            Guid EmptyGuid = Guid.Empty;
            _validator.ShouldNotHaveValidationErrorFor(updateFoodBusinessCommand => updateFoodBusinessCommand.CmdId, EmptyGuid);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            string IncorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessCommand => updateFoodBusinessCommand.NameEnglish, IncorrectName);
        }
    }
}
