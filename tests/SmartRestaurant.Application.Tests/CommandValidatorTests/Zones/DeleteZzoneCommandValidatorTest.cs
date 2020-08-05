using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Zones.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Zones
{
    public class DeleteZzoneCommandValidatorTest
    {
        private readonly DeleteZoneCommandValidator _validator;
        public DeleteZzoneCommandValidatorTest()
        {
            _validator = new DeleteZoneCommandValidator();
        }
        [Fact]
        public void Given_EmptyFoodBusinessId_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.ZoneId, emptyGuid);
        }

    }
}
