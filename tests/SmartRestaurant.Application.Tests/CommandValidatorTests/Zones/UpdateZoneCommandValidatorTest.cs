using System;
using FluentValidation.TestHelper;
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
    }
}