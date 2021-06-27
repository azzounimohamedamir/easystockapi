using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusiness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusiness
{
    public class CreateFoodBusinessCommandValidatorTests
    {
        private readonly CreateFoodBusinessCommandValidator _validator;

        public CreateFoodBusinessCommandValidatorTests()
        {
            _validator = new CreateFoodBusinessCommandValidator();
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(foodBusiness => foodBusiness.Name, incorrectName);
        }

        [Fact]
        public void Given_EmptyEnglishName_WhenOtherNameIsNot_ShouldNotBeError()
        {
            var frenchName = "fast food";
            _validator.ShouldNotHaveValidationErrorFor(foodBusiness => foodBusiness.Name, frenchName);
        }

        [Fact]
        public void Given_EmptyFoodBusinessAdmin_WhenValidating_ShouldError()
        {
            var adminId = string.Empty;
            _validator.ShouldHaveValidationErrorFor(foodBusiness => foodBusiness.FoodBusinessAdministratorId, adminId);
        }
    }
}