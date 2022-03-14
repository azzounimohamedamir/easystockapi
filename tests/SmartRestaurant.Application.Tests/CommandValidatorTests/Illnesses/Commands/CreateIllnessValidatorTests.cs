using FluentValidation.TestHelper;
using SmartRestaurant.Application.Illness.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Illnesses.Commands
{
    public class CreateIllnessValidatorTests
    {
        private readonly CreateIllnessCommandValidator _validator;
        public CreateIllnessValidatorTests()
        {
            _validator = new CreateIllnessCommandValidator();
        }
        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(illness => illness.Name, incorrectName);
        }
    }
}
