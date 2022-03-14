

using FluentValidation.TestHelper;
using SmartRestaurant.Application.Accounts.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Accounts.Commands
{
    public class ResetPasswordCommandTests
    {
        private readonly ResetPasswordCommandValidator _validator;

        public ResetPasswordCommandTests()
        {
            _validator = new ResetPasswordCommandValidator();
        }

        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Id, _null);
        }

        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, empty);
        }

        [Fact]
        public void Given_IdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.Id, emptyGuid);
        }

        [Fact]
        public void Given_IdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, validEntry);
        }

        [Fact]
        public void Given_PasswordIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Password, _null);
        }

        [Fact]
        public void Given_PasswordIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Password, empty);
        }

        [Fact]
        public void Given_PasswordIsLessThanMinimumLenght_WhenValidating_ShouldGetAnError()
        {
            var lessThanMinimumLenght = "12345";
            _validator.ShouldHaveValidationErrorFor(x => x.Password, lessThanMinimumLenght);
        }

        [Fact]
        public void Given_PasswordIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "dgh54$a9A";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Password, validEntry);
        }
       
        [Fact]
        public void Given_TokenIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Token, _null);
        }

        [Fact]
        public void Given_TokenIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Token, empty);
        }
    }
}
