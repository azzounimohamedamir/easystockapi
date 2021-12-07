using FluentValidation.TestHelper;
using SmartRestaurant.Application.Menus.Queries;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Menus.Commands
{
    public class GetActiveMenuQueryValidatorTests
    {
        private readonly GetActiveMenuQueryValidator _validator;

        public GetActiveMenuQueryValidatorTests()
        {
            _validator = new GetActiveMenuQueryValidator();
        }

        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, _null);
        }

        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, empty);
        }

        [Fact]
        public void Given_IdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, emptyGuid);
        }

        [Fact]
        public void Given_IdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, invalidGuid);
        }

        [Fact]
        public void Given_IdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessId, validEntry);
        }
    }
}
