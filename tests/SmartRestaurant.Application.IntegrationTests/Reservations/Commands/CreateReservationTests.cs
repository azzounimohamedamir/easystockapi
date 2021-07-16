using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Constants;
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
                ReservationName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = fastFood.FoodBusinessId,
                CreatedBy = Guid.NewGuid().ToString(),
                CreatorType = ReservationsConstants.CreatorType.FoodBusinessManager
            };
            var validationResult = await SendAsync(createReservationCommand);
            var createdReservation = await FindAsync<Reservation>(createReservationCommand.CmdId);
            validationResult.Should().Be(default(ValidationResult));
            createdReservation.Should().NotBeNull();
            createdReservation.ReservationId.Should().Be(createReservationCommand.CmdId);
            createdReservation.ReservationName.Should().BeEquivalentTo(createReservationCommand.ReservationName);
            createdReservation.NumberOfDiners.Should().Be(createReservationCommand.NumberOfDiners);
            createdReservation.ReservationDate.Should().Be(createReservationCommand.ReservationDate);
            createdReservation.FoodBusinessId.Should().Be(createReservationCommand.FoodBusinessId);
            createdReservation.CreatedBy.Should().Be(createReservationCommand.CreatedBy);
            createdReservation.CreatedAt.Should().Be(createReservationCommand.CreatedAt);
            createdReservation.CreatorType.Should().Be(createReservationCommand.CreatorType);
            createdReservation.LastModifiedBy.Should().BeNull();
            createdReservation.LastModifiedAt.Should().Be(default);
        }
    }
}