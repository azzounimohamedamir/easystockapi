using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Users.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Users.Commands
{
    public class SetNewPasswordForFoodBusinessAdministratorCommandValidatorTests
    {
        private readonly SetNewPasswordForFoodBusinessAdministratorCommandValidator _validator;

        public SetNewPasswordForFoodBusinessAdministratorCommandValidatorTests()
        {
            _validator = new SetNewPasswordForFoodBusinessAdministratorCommandValidator();
        }

        [Fact]
        public void Given_ListOfFoodBusinessesIdsIsNull_WhenValidating_ShouldGetAnError()
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
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, _null);
        }

        [Fact]
        public void Given_PasswordIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, empty);
        }

        [Fact]
        public void Given_PasswordIsLessThanMinimumLenght_WhenValidating_ShouldGetAnError()
        {
            var lessThanMinimumLenght = "12345";
            _validator.ShouldHaveValidationErrorFor(x => x.NewPassword, lessThanMinimumLenght);
        }

        [Fact]
        public void Given_PasswordIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "dgh54$a9A";
            _validator.ShouldNotHaveValidationErrorFor(x => x.NewPassword, validEntry);
        }
    }
}