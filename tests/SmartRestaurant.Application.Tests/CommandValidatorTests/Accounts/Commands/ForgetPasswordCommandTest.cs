using FluentValidation.TestHelper;
using SmartRestaurant.Application.Accounts.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Accounts.Commands
{
    public class ForgetPasswordCommandTest
    {
        private readonly ForgetPasswordCommandValidator _validator;

        public ForgetPasswordCommandTest()
        {
            _validator = new ForgetPasswordCommandValidator();
        }

        [Fact]
        public void Given_EmailIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(x => x.Email, empty);
        }

        [Fact]
        public void Given_EmailIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Email, _null);
        }

        [Fact]
        public void Given_EmailExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt@test.com";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, exceedMax);
        }

        [Fact]
        public void Given_EmailIsInvalid_WhenValidating_ShouldGetAnError()
        {
            var invalidEmail = "test@test.";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, invalidEmail);
        }

        [Fact]
        public void Given_EmailIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "test@test.com";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, validEntry);
        }
    }
}
