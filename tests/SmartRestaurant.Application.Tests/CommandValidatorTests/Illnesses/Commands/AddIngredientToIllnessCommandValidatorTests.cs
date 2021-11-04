using FluentValidation.TestHelper;
using SmartRestaurant.Application.Illness.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Illnesses.Commands
{
    public class AddIngredientToIllnessCommandValidatorTests
    {
        private readonly AddIngredientToIllnessCommandValidator _validator;

        public AddIngredientToIllnessCommandValidatorTests()
        {
            _validator = new AddIngredientToIllnessCommandValidator();
        }

        [Fact]
        public void Given_IllnessIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.IllnessId, _null);
        }

        [Fact]
        public void Given_IllnessIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.IllnessId, empty);
        }

        [Fact]
        public void Given_IllnessIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.IllnessId, emptyGuid);
        }

        [Fact]
        public void Given_IllnessIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.IllnessId, invalidGuid);
        }

        [Fact]
        public void Given_IllnessIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.IllnessId, validEntry);
        }

        [Fact]
        public void Given_IngredientIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.IngredientId, _null);
        }

        [Fact]
        public void Given_IngredientIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.IngredientId, empty);
        }

        [Fact]
        public void Given_IngredientIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.IngredientId, emptyGuid);
        }

        [Fact]
        public void Given_IngredientIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.IngredientId, invalidGuid);
        }

        [Fact]
        public void Given_IngredientIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.IngredientId, validEntry);
        }
    }
}
