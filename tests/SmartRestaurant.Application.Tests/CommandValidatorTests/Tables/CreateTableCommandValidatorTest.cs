using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Tables.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Tables
{
    public class CreateTableCommandValidatorTest
    {
        private readonly CreateTableCommandValidator _validator;

        public CreateTableCommandValidatorTest()
        {
            _validator = new CreateTableCommandValidator();
        }

        [Fact]
        public void Given_ZeroCapacity_WhenValidating_ShouldError()
        {
            var zero = 0;
            _validator.ShouldHaveValidationErrorFor(tbl => tbl.Capacity, zero);
        }

        [Fact]
        public void Given_MaxCapacity_WhenValidating_ShouldError()
        {
            var max = 100;
            _validator.ShouldHaveValidationErrorFor(tbl => tbl.Capacity, max);
        }

        [Fact]
        public void Given_EmptyZoneId_WhenValidating_ShouldError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(query => query.ZoneId, empty);
        }

        [Fact]
        public void Given_TableZoneIdIsEmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = "00000000-0000-0000-0000-000000000000";
            _validator.ShouldHaveValidationErrorFor(query => query.ZoneId, emptyGuid);
        }

        [Fact]
        public void Given_TableZoneIdIsInvalidGuid_WhenValidating_ShouldError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(query => query.ZoneId, invalidGuid);
        }

        [Fact]
        public void Given_TableZoneId_WhenValidating_ShouldBeValidated()
        {
            var validGuid = "3cbf3570-4444-4673-8746-29b7cf568093";
            _validator.ShouldNotHaveValidationErrorFor(query => query.ZoneId, validGuid);
        }
    }
}