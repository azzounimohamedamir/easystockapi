using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Restaurant
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
        [Fact]
        public void Given_EmptyEnglishName_WhenOtherNameIsNot_ShouldNotBeError()
        {
            
            string frenchName = "fast food";
            _validator.ShouldNotHaveValidationErrorFor(restaurant => restaurant.NameFrench, frenchName);
        }
        [Fact]
        public void Given_EmptyFoodBusinessAdmin_WhenValidating_ShouldError()
        {
            string adminId = string.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.RestaurantAdministratorId, adminId);
        }
    }
}