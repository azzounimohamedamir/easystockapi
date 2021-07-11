using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Zones.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Zones
{
    public class DeleteZoneCommandValidatorTest
    {
        private readonly DeleteZoneCommandValidator _validator;

        public DeleteZoneCommandValidatorTest()
        {
            _validator = new DeleteZoneCommandValidator();
        }

        [Fact]
        public void Given_EmptyZoneId_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(zone => zone.CmdId, emptyGuid);
        }
    }
}