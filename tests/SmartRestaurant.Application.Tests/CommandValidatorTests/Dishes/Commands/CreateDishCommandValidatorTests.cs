using FluentValidation.TestHelper;
using SmartRestaurant.Application.Dishes.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Dishes.Commands
{
    
    public class CreateDishCommandValidatorTests
    {
        private readonly CreateDishCommandValidator _validator;

        public CreateDishCommandValidatorTests()
        {
            _validator = new CreateDishCommandValidator();
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
        public void Given_PictureIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Picture, _null);
        }

        [Fact]
        public void Given_PriceIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            var lessThanZero = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Price, lessThanZero);
        }

        [Fact]
        public void Given_DescriptionExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvtestttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvtesttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt";
            _validator.ShouldHaveValidationErrorFor(x => x.Description, exceedMax);
        }

        [Fact]
        public void Given_FoodBusinessIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, _null);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, empty);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessId, validEntry);
        }



        [Fact]
        public void Given_EstimatedPreparationTimeHasNegativeValue_WhenValidating_ShouldGetAnError()
        {
            var negativeNumber = -1 ;
            _validator.ShouldHaveValidationErrorFor(x => x.EstimatedPreparationTime, negativeNumber);
        }        
    }
}
