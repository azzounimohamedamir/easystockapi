using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Reservations.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateReservationTests : TestBase
    {


        [Test]
        public async Task UpdatedReservation_ShouldBeSavedToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            
            var createReservationCommand = new CreateReservationCommand
            {
                ReservationName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(createReservationCommand);
            var reservation = await FindAsync<Reservation>(createReservationCommand.CmdId);


            var updateReservationCommand = new UpdateReservationCommand
            {
                ReservationName = "bilal",
                NumberOfDiners = 5,
                ReservationDate = DateTime.Now.AddDays(5),
                CmdId = reservation.ReservationId,
                LastModifiedBy = Guid.NewGuid().ToString(),
            };
            var validationResult = await SendAsync(updateReservationCommand);
            var updatedReservation = await FindAsync<Reservation>(updateReservationCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            updatedReservation.Should().NotBeNull();
            updatedReservation.ReservationId.Should().Be(updateReservationCommand.CmdId);
            updatedReservation.ReservationName.Should().BeEquivalentTo(updateReservationCommand.ReservationName);
            updatedReservation.NumberOfDiners.Should().Be(updateReservationCommand.NumberOfDiners);
            updatedReservation.ReservationDate.Should().Be(updateReservationCommand.ReservationDate);
            updatedReservation.FoodBusinessId.Should().Be(reservation.FoodBusinessId);
            updatedReservation.CreatedBy.Should().Be(reservation.CreatedBy);
            updatedReservation.CreatedAt.Should().Be(reservation.CreatedAt);
            updatedReservation.LastModifiedBy.Should().Be(updateReservationCommand.LastModifiedBy);
            updatedReservation.LastModifiedAt.Should().Be(updateReservationCommand.LastModifiedAt);
        }
    }
}