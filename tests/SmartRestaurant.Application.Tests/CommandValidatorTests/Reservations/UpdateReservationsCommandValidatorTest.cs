using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Reservations.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Reservations
{
    public class UpdateReservationsCommandValidatorTest
    {
        private readonly UpdateReservationCommandValidator _validator;

        public UpdateReservationsCommandValidatorTest()
        {
            _validator = new UpdateReservationCommandValidator();
        }

        [Fact]
        public void Given_ClientName_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "Aissa";
            _validator.ShouldNotHaveValidationErrorFor(R => R.ReservationName, validEntry);
        }

        [Fact]
        public void Given_ClientNameExeedsMaximumLength_WhenValidating_ShouldGetAnError()
        {
            var entryNotRespectingMaxLength =
                "hUzzub8gB6NYKpvNvwOJ5fJQZcSaa34oOV4xmDpYKIQO4qukyPgFaWjZbzW3fwBHX53D60zCRLmluTqc1dSlHZeRZkuXQlhotluEPNni2zEhb93PvNjcu788iQRGR9aAPtFN4bICsbRGfv6l8dQQe23gAoP2WNjN87B5BXoV4MwrSAqPvJy6BEXBhq32DxxWw5NgVhotc";
            _validator.ShouldHaveValidationErrorFor(R => R.ReservationName, entryNotRespectingMaxLength);
        }

        [Fact]
        public void Given_ClientNameLessThanMinimumLength_WhenValidating_ShouldGetAnError()
        {
            var entryNotRespectingMinLength = "jAFT";
            _validator.ShouldHaveValidationErrorFor(R => R.ReservationName, entryNotRespectingMinLength);
        }

        [Fact]
        public void Given_ReservationNameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(R => R.ReservationName, empty);
        }

        [Fact]
        public void Given_NumberOfDiners_WhenValidating_ShouldBeValidated()
        {
            var validEntry = 15;
            _validator.ShouldNotHaveValidationErrorFor(reservation => reservation.NumberOfDiners, validEntry);
        }

        [Fact]
        public void Given_NumberOfDinersEqualZero_WhenValidating_ShouldGetAnError()
        {
            var zero = 0;
            _validator.ShouldHaveValidationErrorFor(reservation => reservation.NumberOfDiners, zero);
        }

        [Fact]
        public void Given_NumberOfDinersExeedsMaximum_WhenValidating_ShouldGetAnError()
        {
            var ExeedsMaximum = 1001;
            _validator.ShouldHaveValidationErrorFor(reservation => reservation.NumberOfDiners, ExeedsMaximum);
        }

        [Fact]
        public void Given_ReservationDate_WhenValidating_ShouldBeValidated()
        {
            var validEntry = DateTime.Now.AddDays(1);
            _validator.ShouldNotHaveValidationErrorFor(reservation => reservation.ReservationDate, validEntry);
        }

        [Fact]
        public void Given_ReservationDateIsPastDate_WhenValidating_ShouldGetAnError()
        {
            var pastDate = DateTime.Now.AddDays(-1);
            _validator.ShouldHaveValidationErrorFor(reservation => reservation.ReservationDate, pastDate);
        }

        [Fact]
        public void Given_EmptyReservationId_WhenValidating_ShouldGetAnError()
        {
            var empty = Guid.Empty;
            _validator.ShouldHaveValidationErrorFor(reservation => reservation.CmdId, empty);
        }
    }
}