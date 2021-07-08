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
            //Create a FoodBusiness
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);


            //Create Reservation
            var createReservationCommand = new CreateReservationCommand
            {
                ClientName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createReservationCommand);
            var reservation = await FindAsync<Domain.Entities.Reservation>(createReservationCommand.CmdId);


            // Update Reservation
            var updateReservationCommand = new UpdateReservationCommand
            {
                ClientName = "bilal",
                NumberOfDiners = 5,
                ReservationDate = DateTime.Now.AddDays(5),
                CmdId = reservation.ReservationId               
            };
            var validationResult = await SendAsync(updateReservationCommand);
            var updatedReservation = await FindAsync<Reservation>(updateReservationCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            updatedReservation.Should().NotBeNull();
            updatedReservation.ReservationId.Should().Be(updateReservationCommand.CmdId);
            updatedReservation.ClientName.Should().BeEquivalentTo(updateReservationCommand.ClientName);
            updatedReservation.NumberOfDiners.Should().Be(updateReservationCommand.NumberOfDiners);
            updatedReservation.ReservationDate.Should().Be(updateReservationCommand.ReservationDate);
            updatedReservation.FoodBusinessId.Should().Be(reservation.FoodBusinessId);
        }
    }
}