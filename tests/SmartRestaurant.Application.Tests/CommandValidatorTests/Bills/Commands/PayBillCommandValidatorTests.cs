using FluentValidation.TestHelper;
using SmartRestaurant.Application.Bills.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Bills  .Commands
{
    public class PayBillCommandValidatorTests
    {
        private readonly PayBillCommandValidator _validator;

        public PayBillCommandValidatorTests()
        {
            _validator = new PayBillCommandValidator();
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
        public void Given_IdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, validEntry);
        }

        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Id, _null);
        }
    }
}
