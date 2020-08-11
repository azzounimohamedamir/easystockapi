using FluentValidation.TestHelper;
using SmartRestaurant.Application.Tables.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Tables
{
    public class UpdateTableCommandValidatorTest
    {
        private UpdateTableCommandValidator _validator;
        public UpdateTableCommandValidatorTest()
        {
            _validator = new UpdateTableCommandValidator();
        }
        [Fact]
        public void Given_TableNumberEqualZero_WhenValidating_ShouldError()
        {
            int zero = 0;
            _validator.ShouldHaveValidationErrorFor(tbl => tbl.TableNumber, zero);
        }
        [Fact]
        public void Given_ZeroCapacity_WhenValidating_ShouldError()
        {
            int zero = 0;
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
