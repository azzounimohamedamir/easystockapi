using FluentValidation.TestHelper;
using SmartRestaurant.Application.Sections.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Sections.Commands
{
    public class RemoveDishFromSectionCommandValidatorTests
    {
        private readonly RemoveDishFromSectionCommandValidator _validator;

        public RemoveDishFromSectionCommandValidatorTests()
        {
            _validator = new RemoveDishFromSectionCommandValidator();
        }

        [Fact]
        public void Given_SectionIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.SectionId, _null);
        }

        [Fact]
        public void Given_SectionIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.SectionId, empty);
        }

        [Fact]
        public void Given_SectionIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.SectionId, emptyGuid);
        }

        [Fact]
        public void Given_SectionIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.SectionId, invalidGuid);
        }

        [Fact]
        public void Given_SectionIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.SectionId, validEntry);
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
