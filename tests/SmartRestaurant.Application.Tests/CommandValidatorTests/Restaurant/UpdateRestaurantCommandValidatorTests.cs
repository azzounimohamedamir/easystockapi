using FluentValidation.TestHelper;
using SmartRestaurant.Application.Restaurants.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests
{
    public class UpdateRestaurantCommandValidatorTests
    {
        private readonly UpdateRestaurantCommandValidator _validator;

        public UpdateRestaurantCommandValidatorTests()
        {
            _validator = new UpdateRestaurantCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            Guid EmptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.RestaurantId, EmptyGuid);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            string IncorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.NameEnglish, IncorrectName);
        }
    }
}
