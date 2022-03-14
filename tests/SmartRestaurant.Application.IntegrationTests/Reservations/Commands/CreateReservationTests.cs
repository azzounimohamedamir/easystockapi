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
    public class CreateReservationTests : TestBase
    {
        [Test]
        public async Task CreateReservation_ShouldSaveToDB()
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
            var createdReservation = await FindAsync<Reservation>(createReservationCommand.Id);

            createdReservation.Should().NotBeNull();
            createdReservation.ReservationId.Should().Be(createReservationCommand.Id);
            createdReservation.ReservationName.Should().BeEquivalentTo(createReservationCommand.ReservationName);
            createdReservation.NumberOfDiners.Should().Be(createReservationCommand.NumberOfDiners);
            createdReservation.ReservationDate.Should().Be(createReservationCommand.ReservationDate);
            createdReservation.FoodBusinessId.Should().Be(createReservationCommand.FoodBusinessId);
            createdReservation.CreatedBy.Should().Be(createReservationCommand.CreatedBy);
            createdReservation.CreatedAt.Should().Be(createReservationCommand.CreatedAt);
            createdReservation.LastModifiedBy.Should().BeNull();
            createdReservation.LastModifiedAt.Should().Be(default);
        }
    }
}