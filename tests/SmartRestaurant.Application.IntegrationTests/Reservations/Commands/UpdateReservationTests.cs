using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
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
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createReservationCommand = new CreateReservationCommand
            {
                ReservationName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(createReservationCommand);
            var reservation = await FindAsync<Reservation>(createReservationCommand.Id);


            var updateReservationCommand = new UpdateReservationCommand
            {
                ReservationName = "bilal",
                NumberOfDiners = 5,
                ReservationDate = DateTime.Now.AddDays(5),
                Id = reservation.ReservationId,
                LastModifiedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(updateReservationCommand);
            var updatedReservation = await FindAsync<Reservation>(updateReservationCommand.Id);

            updatedReservation.Should().NotBeNull();
            updatedReservation.ReservationId.Should().Be(updateReservationCommand.Id);
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