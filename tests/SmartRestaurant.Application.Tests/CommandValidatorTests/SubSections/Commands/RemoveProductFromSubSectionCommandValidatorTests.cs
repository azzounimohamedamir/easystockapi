using FluentValidation.TestHelper;
using SmartRestaurant.Application.SubSections.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.SubSections.Commands
{
    public class RemoveProductFromSubSectionCommandValidatorTests
    {
        private readonly RemoveProductFromSubSectionCommandValidator _validator;

        public RemoveProductFromSubSectionCommandValidatorTests()
        {
            _validator = new RemoveProductFromSubSectionCommandValidator();
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
        public void Given_ProductIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, _null);
        }

        [Fact]
        public void Given_ProductIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, empty);
        }

        [Fact]
        public void Given_ProductIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, emptyGuid);
        }

        [Fact]
        public void Given_ProductIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.ProductId, invalidGuid);
        }

        [Fact]
        public void Given_ProductIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProductId, validEntry);
        }
    }
}
