using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Reservations.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Reservations.Queries
{
    using static Testing;

    [TestFixture]
    public class GetReservationByIdTest : TestBase
    {
        [Test]
        public async Task ShouldGetReservation_ById()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);


            var createReservationCommand = new CreateReservationCommand
            {
                ReservationName = "Reservation Test",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString()
            };
            await SendAsync(createReservationCommand);

            var query = new GetReservationByIdQuery {ReservationId = createReservationCommand.Id};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.ReservationName.Should().Be("Reservation Test");
        }
    }
}