using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Reservations.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Reservations
{
    public class DeleteReservationCommandValidatorTests
    {
        private readonly DeleteReservationCommandValidator _validator;

        public DeleteReservationCommandValidatorTests()
        {
            _validator = new DeleteReservationCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(restaurant => restaurant.CmdId, emptyGuid);
        }
    }
}