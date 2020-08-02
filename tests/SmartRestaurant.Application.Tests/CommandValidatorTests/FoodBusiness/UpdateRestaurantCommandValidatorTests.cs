using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Restaurant
{
    public class UpdateRestaurantCommandValidatorTests
    {
        private readonly UpdateFoodBusinessCommandValidator _validator;

        public UpdateRestaurantCommandValidatorTests()
        {
            _validator = new UpdateFoodBusinessCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldNotHaveError()
        {
            Guid EmptyGuid = Guid.Empty;
            _validator.ShouldNotHaveValidationErrorFor(restaurant => restaurant.CmdId, EmptyGuid);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            string IncorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.NameEnglish, IncorrectName);
        }
    }
}
