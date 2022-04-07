using FluentValidation.TestHelper;
using SmartRestaurant.Application.Accounts.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Accounts.Commands
{
    public class ConfirmEmailCommadTest
    {
        private readonly ConfirmEmailCommadValidator _validator;

        public ConfirmEmailCommadTest()
        {
            _validator = new ConfirmEmailCommadValidator();
        }


        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.UserId, _null);
        }

        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.UserId, empty);
        }

        [Fact]
        public void Given_IdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.UserId, emptyGuid);
        }

        [Fact]
        public void Given_IdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.UserId, invalidGuid);
        }

        [Fact]
        public void Given_UserIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.UserId, validEntry);
        }
        [Fact]
        public void Given_FullNameExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv";
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, exceedMax);
        }
        [Fact]
        public void Given_FullNameIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, _null);
        }

        [Fact]
        public void Given_FullNameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, empty);
        }

        [Fact]
        public void Given_FullNameIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "teste";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FullName, validEntry);
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
