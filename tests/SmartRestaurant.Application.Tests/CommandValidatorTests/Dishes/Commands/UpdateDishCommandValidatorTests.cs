﻿using FluentValidation.TestHelper;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Dishes.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Dishes.Commands
{
    public class UpdateDishCommandValidatorTests
    {
        private readonly UpdateDishCommandValidator _validator;

        public UpdateDishCommandValidatorTests()
        {
            _validator = new UpdateDishCommandValidator();
        }

        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
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
        public void Given_IdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, validEntry);
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
        public void Given_EstimatedPreparationTimeHasNegativeValue_WhenValidating_ShouldGetAnError()
        {
            var negativeNumber = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.EstimatedPreparationTime, negativeNumber);
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var incorrectName = string.Empty;
            _validator.ShouldHaveValidationErrorFor(illness => illness.Name, incorrectName);
        }

        // names
        [Fact]
        public void Given_NullNames_WhenValidating_ShouldError()
        {
            var commandNullNames = new UpdateDishCommand() { Names = null };
            var result = _validator.TestValidate(commandNullNames);
            result.ShouldHaveValidationErrorFor(person => person.Names);
        }
        [Fact]
        public void Given_NullNameAR_WhenValidating_ShouldError()
        {
            var commandNullEn = new UpdateDishCommand() { Names = new NamesDto() { AR = null, FR = "fr", TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.AR);
        }

        [Fact]
        public void Given_NullNameEN_WhenValidating_ShouldError()
        {
            var commandNullEn = new UpdateDishCommand() { Names = new NamesDto() { AR = "ar", FR = "fr", TR = "tr", RU = "ru", EN = null } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.EN);
        }
        [Fact]
        public void Given_NullNameFR_WhenValidating_ShouldError()
        {
            var commandNullFr = new UpdateDishCommand() { Names = new NamesDto() { AR = "ar", FR = null, TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullFr);
            result.ShouldHaveValidationErrorFor(person => person.Names.FR);
        }
        [Fact]
        public void Given_NullNameTR_WhenValidating_ShouldError()
        {
            var commandNullTr = new UpdateDishCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = null, RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullTr);
            result.ShouldHaveValidationErrorFor(person => person.Names.TR);
        }
        [Fact]
        public void Given_NullNameRU_WhenValidating_ShouldError()
        {
            var commandNullRu = new UpdateDishCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = "Tr", RU = null, EN = "EN" } };
            var result = _validator.TestValidate(commandNullRu);
            result.ShouldHaveValidationErrorFor(person => person.Names.RU);
        }
    }
}
