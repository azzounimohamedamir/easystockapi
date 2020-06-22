using FluentValidation.TestHelper;
using SmartRestaurant.Application.Restaurants.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests
{
    public class CreateRestaurantCommandValidatorTests
    {
        private readonly CreateRestaurantCommandValidator _validator;

        public CreateRestaurantCommandValidatorTests()
        {
            _validator = new CreateRestaurantCommandValidator();
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            string IncorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.NameEnglish, IncorrectName);
        }
    }
}