using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Zones.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Zones
{
    public class UpdateZoneCommandValidatorTest
    {
        private readonly UpdateZoneCommandValidator _validator;

        public UpdateZoneCommandValidatorTest()
        {
            _validator = new UpdateZoneCommandValidator();
        }

        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.ZoneTitle, empty);
        }

        [Fact]
        public void Given_EmptyFoodBusinessId_WhenValidating_ShouldError()
        {
            var guid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.FoodBusinessId, guid);
        }
        [Fact]
        public void Given_NullNames_WhenValidating_ShouldError()
        {
            var commandNullNames = new UpdateZoneCommand() { Names = null };
            var result = _validator.TestValidate(commandNullNames);
            result.ShouldHaveValidationErrorFor(person => person.Names);
        }
        [Fact]
        public void Given_NullNameAR_WhenValidating_ShouldError()
        {
            var commandNullEn = new UpdateZoneCommand() { Names = new NamesDto() { AR = null, FR = "fr", TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.AR);
        }

        [Fact]
        public void Given_NullNameEN_WhenValidating_ShouldError()
        {
            var commandNullEn = new UpdateZoneCommand() { Names = new NamesDto() { AR = "ar", FR = "fr", TR = "tr", RU = "ru", EN = null } };
            var result = _validator.TestValidate(commandNullEn);
            result.ShouldHaveValidationErrorFor(person => person.Names.EN);
        }
        [Fact]
        public void Given_NullNameFR_WhenValidating_ShouldError()
        {
            var commandNullFr = new UpdateZoneCommand() { Names = new NamesDto() { AR = "ar", FR = null, TR = "tr", RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullFr);
            result.ShouldHaveValidationErrorFor(person => person.Names.FR);
        }
        [Fact]
        public void Given_NullNameTR_WhenValidating_ShouldError()
        {
            var commandNullTr = new UpdateZoneCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = null, RU = "ru", EN = "EN" } };
            var result = _validator.TestValidate(commandNullTr);
            result.ShouldHaveValidationErrorFor(person => person.Names.TR);
        }
        [Fact]
        public void Given_NullNameRU_WhenValidating_ShouldError()
        {
            var commandNullRu = new UpdateZoneCommand() { Names = new NamesDto() { AR = "ar", FR = "FR", TR = "Tr", RU = null, EN = "EN" } };
            var result = _validator.TestValidate(commandNullRu);
            result.ShouldHaveValidationErrorFor(person => person.Names.RU);
        }
    }
}