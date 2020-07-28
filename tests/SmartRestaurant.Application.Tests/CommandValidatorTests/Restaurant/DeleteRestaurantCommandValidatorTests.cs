using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Restaurant
{
    public class DeleteRestaurantCommandValidatorTests
    {
        private readonly DeleteRestaurantCommandValidator _validator;

        public DeleteRestaurantCommandValidatorTests()
        {
            _validator = new DeleteRestaurantCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            Guid EmptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.RestaurantId, EmptyGuid);
        }
    }
}