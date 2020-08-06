using FluentValidation.TestHelper;
using SmartRestaurant.Application.Zones.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Zones
{
    public class CreateZoneCommandValidatorTest
    {
        private readonly CreateZoneCommandValidator _validator;

        public CreateZoneCommandValidatorTest()
        {
            _validator = new CreateZoneCommandValidator();
        }
        [Fact]
        public void Given_EmptyName_WhenValidating_ShouldError()
        {
            string empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.ZoneTitle, empty);
        }
        [Fact]
        public void Given_EmptyFoodBusinessId_WhenValidating_ShouldError()
        {
            var adminId = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.FoodBusinessId, adminId);
        }
    }
}
