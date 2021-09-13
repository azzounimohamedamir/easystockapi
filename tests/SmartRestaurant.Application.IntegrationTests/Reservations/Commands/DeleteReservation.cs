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
    public class DeleteReservation : TestBase
    {
        [Test]
        public async Task DeleteReservation_ShouldBeRemovedFromDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createReservationCommand = new CreateReservationCommand
            {
                ReservationName = "Salim",
                NumberOfDiners = 9,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(createReservationCommand);
            var reservation = await FindAsync<Reservation>(createReservationCommand.Id);

            await SendAsync(new DeleteReservationCommand
            {
                Id = createReservationCommand.Id
            });
            var item = await FindAsync<Reservation>(reservation.ReservationId);
            item.Should().BeNull();
        }
    }
}