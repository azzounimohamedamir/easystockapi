using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessClient
{
    public class UpdateFoodBusinessClientCommandValidatorTests
    {
        private readonly UpdateFoodBusinessClientCommandValidator _validator;
        public UpdateFoodBusinessClientCommandValidatorTests()
        {
            _validator = new UpdateFoodBusinessClientCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Id,
                emptyGuid);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Name,
                incorrectName);
        }
    }
}
