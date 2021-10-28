using FluentValidation.TestHelper;
using SmartRestaurant.Application.SubSections.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.SubSections.Commands
{
    public class AddDishToSubSectionCommandValidatorTests
    {
        private readonly AddDishToSubSectionCommandValidator _validator;

        public AddDishToSubSectionCommandValidatorTests()
        {
            _validator = new AddDishToSubSectionCommandValidator();
        }

        [Fact]
        public void Given_SubSectionIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.SubSectionId, _null);
        }

        [Fact]
        public void Given_SubSectionIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.SubSectionId, empty);
        }

        [Fact]
        public void Given_SubSectionIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.SubSectionId, emptyGuid);
        }

        [Fact]
        public void Given_SubSectionIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.SubSectionId, invalidGuid);
        }

        [Fact]
        public void Given_SubSectionIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.SubSectionId, validEntry);
        }

        [Fact]
        public void Given_DishIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.DishId, _null);
        }

        [Fact]
        public void Given_DishIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.DishId, empty);
        }

        [Fact]
        public void Given_DishIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.DishId, emptyGuid);
        }

        [Fact]
        public void Given_DishIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.DishId, invalidGuid);
        }

        [Fact]
        public void Given_DishIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.DishId, validEntry);
        }
    }
}
