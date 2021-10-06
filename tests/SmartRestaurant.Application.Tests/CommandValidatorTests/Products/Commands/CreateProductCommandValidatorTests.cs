using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Products.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Products.Commands
{
    public class CreateProductCommandValidatorTests
    {
        private readonly CreateProductCommandValidator _validator;

        public CreateProductCommandValidatorTests()
        {
            _validator = new CreateProductCommandValidator();
        }

        [Fact]
        public void Given_NameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, empty);
        }

        [Fact]
        public void Given_NameIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, _null);
        }

        [Fact]
        public void Given_NameExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv";
            _validator.ShouldHaveValidationErrorFor(x => x.Name, exceedMax);
        }
        [Fact]
        public void Given_SectionIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid =  Guid.Empty.ToString();
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
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315" ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.SectionId, validEntry);
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
        public void Given_PictureIdIsNull_WhenValidating_ShouldGetAnError()
        {
            FormFile _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Picture, _null);
        }

        [Fact]
        public void Given_PriceIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            var lessThanZero = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Price, lessThanZero);
        }

        [Fact]
        public void Given_EnergeticValueIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            var lessThanZero = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue, lessThanZero);
        }

        [Fact]
        public void Given_DescriptionExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvtestttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvtesttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt";
            _validator.ShouldHaveValidationErrorFor(x => x.Description, exceedMax);
        }
    }
}
