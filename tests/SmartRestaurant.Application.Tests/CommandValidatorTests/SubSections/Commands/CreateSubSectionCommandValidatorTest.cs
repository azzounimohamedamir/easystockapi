using FluentValidation.TestHelper;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.SubSections.Commands
{
    public class CreateSubSectionCommandValidatorTest
    {
        private readonly CreateSubSectionCommandValidator _validator;

        public CreateSubSectionCommandValidatorTest()
        {
            _validator = new CreateSubSectionCommandValidator();
        }


        [Fact]
        public void Given_NullNames_WhenValidating_ShouldError()
        {
            var commandNullNames = new CreateSubSectionCommand() { Names = null };
            var result = _validator.TestValidate(commandNullNames);
            result.ShouldHaveValidationErrorFor(person => person.Names);
        }
        [Fact]
        public void Given_NullNameAR_WhenValidating_ShouldError()
        {
            var commandNullEn = new CreateSubSectionCommand() { Names = new NamesDto() { AR = null, FR = "fr", TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.AR);
        }

        [Fact]
        public void Given_NullNameEN_WhenValidating_ShouldError()
        {
            var commandNullEn = new CreateSubSectionCommand() { Names = new NamesDto() { AR = "ar", FR = "fr", TR = "tr", RU = "ru", EN = null } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.EN);
        }
        [Fact]
        public void Given_NullNameFR_WhenValidating_ShouldError()
        {
            var commandNullFr = new CreateSubSectionCommand() { Names = new NamesDto() { AR = "ar", FR = null, TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullFr);
            result.ShouldHaveValidationErrorFor(person => person.Names.FR);
        }
        [Fact]
        public void Given_NullNameTR_WhenValidating_ShouldError()
        {
            var commandNullTr = new CreateSubSectionCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = null, RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullTr);
            result.ShouldHaveValidationErrorFor(person => person.Names.TR);
        }
        [Fact]
        public void Given_NullNameRU_WhenValidating_ShouldError()
        {
            var commandNullRu = new CreateSubSectionCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = "Tr", RU = null, EN = "EN" } };
            var result = _validator.TestValidate(commandNullRu);
            result.ShouldHaveValidationErrorFor(person => person.Names.RU);
        }
        [Fact]
        public void Given_OrderIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            var lessThanZero = -1;
            _validator.ShouldHaveValidationErrorFor(x => x.Order, lessThanZero);
        }
        [Fact]
        public void Given_OrderIsZero_WhenValidating_ShouldGetAnError()
        {
            var Zero = 0;
            _validator.ShouldHaveValidationErrorFor(x => x.Order, Zero);
        }
    }
}
