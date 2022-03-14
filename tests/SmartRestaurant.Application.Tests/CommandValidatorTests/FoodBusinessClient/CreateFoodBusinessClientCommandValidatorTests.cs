using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessClient
{
    public class CreateFoodBusinessClientCommandValidatorTests
    {
        private readonly CreateFoodBusinessClientCommandValidator _validator;
        public CreateFoodBusinessClientCommandValidatorTests()
        {
            _validator = new CreateFoodBusinessClientCommandValidator();
        }
        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(foodBusinessClient => foodBusinessClient.Name, incorrectName);
        }
       
    }
}
