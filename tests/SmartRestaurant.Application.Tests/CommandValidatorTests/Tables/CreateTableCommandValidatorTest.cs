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
        public void Given_TableNumberEqualZero_WhenValidating_ShouldError()
        {
            var zero = 0;
            _validator.ShouldHaveValidationErrorFor(tbl => tbl.TableNumber, zero);
        }

        [Fact]
        public void Given_ZeroCapacity_WhenValidating_ShouldError()
        {
            var zero = 0;
            _validator.ShouldHaveValidationErrorFor(tbl => tbl.Capacity, zero);
        }

        [Fact]
        public void Given_EmptyZoneId_WhenValidating_ShouldError()
        {
            var empty = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.ZoneId, empty);
        }
    }
}