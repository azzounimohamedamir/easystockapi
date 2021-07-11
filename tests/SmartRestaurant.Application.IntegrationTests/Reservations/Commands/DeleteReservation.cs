using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Reservations.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteReservation : TestBase
    {
        [Test]
        public async Task DeleteReservation_ShouldBeRemovedFromDB()
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
                ReservationName = "Salim",
                NumberOfDiners = 9,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(createReservationCommand);
            var reservation = await FindAsync<Reservation>(createReservationCommand.CmdId);

            await SendAsync(new DeleteReservationCommand
            {
                CmdId = createReservationCommand.CmdId
            });
            var item = await FindAsync<Reservation>(reservation.ReservationId);
            item.Should().BeNull();
        }
    }
}