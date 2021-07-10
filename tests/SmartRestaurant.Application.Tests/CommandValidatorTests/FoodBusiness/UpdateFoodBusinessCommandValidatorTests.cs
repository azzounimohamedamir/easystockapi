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
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessCommand => updateFoodBusinessCommand.CmdId, emptyGuid);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessCommand => updateFoodBusinessCommand.Name,
                incorrectName);
        }
    }
}