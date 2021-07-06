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
    public class CreateReservationTests : TestBase
    {
        [Test]
        public async Task CreateReservation_ShouldSaveToDB()
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
                ClientName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId
            };
            var validationResult = await SendAsync(createReservationCommand);
            var item = await FindAsync<Reservation>(createReservationCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.ReservationId.Should().Be(createReservationCommand.CmdId);
            item.ClientName.Should().BeEquivalentTo(createReservationCommand.ClientName);
            item.NumberOfDiners.Should().Be(createReservationCommand.NumberOfDiners);
            item.ReservationDate.Should().Be(createReservationCommand.ReservationDate);
            item.FoodBusinessId.Should().Be(createReservationCommand.FoodBusinessId);
        }
    }
}