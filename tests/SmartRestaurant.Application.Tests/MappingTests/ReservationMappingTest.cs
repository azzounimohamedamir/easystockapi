using System;
using AutoMapper;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class ReservationMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;
        private readonly CreateReservationCommandValidator _createReservationValidator;

        public ReservationMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
            _createReservationValidator = new CreateReservationCommandValidator();
        }


        [Fact]
        public void Map_CreateReservationCommand_To_Reservation_Valide_Test()
        {
            var createReservationCommand = new CreateReservationCommand
            {
                ReservationName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid().ToString()
            };

            var validationResult = _createReservationValidator.Validate(createReservationCommand);
            Assert.True(validationResult.IsValid);

            var reservation = _mapper.Map<Reservation>(createReservationCommand);
            Assert.Equal(reservation.ReservationId, createReservationCommand.CmdId);
            Assert.Equal(reservation.ReservationName, createReservationCommand.ReservationName);
            Assert.Equal(reservation.NumberOfDiners, createReservationCommand.NumberOfDiners);
            Assert.Equal(reservation.ReservationDate, createReservationCommand.ReservationDate);
            Assert.Equal(reservation.FoodBusinessId, createReservationCommand.FoodBusinessId);
            Assert.Equal(reservation.CreatedBy, createReservationCommand.CreatedBy);
            Assert.Equal(reservation.CreatedAt, createReservationCommand.CreatedAt);
            Assert.Null(reservation.LastModifiedBy);
            Assert.Equal(default(DateTime), reservation.LastModifiedAt);

        }

        [Fact]
        public void Map_UpdateReservationCommand_To_Reservation_Valide_Test()
        {
            var reservationId = Guid.NewGuid();
            var reservation = new Reservation
            {
                ReservationName = "bilal",
                NumberOfDiners = 7,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = Guid.NewGuid(),
                ReservationId = reservationId,
                CreatedBy = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };

            var updateReservationCommand = new UpdateReservationCommand
            {
                ReservationName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(2),
                CmdId = reservationId,
                LastModifiedBy = Guid.NewGuid().ToString()


            };        

            var foodBusinessId = reservation.FoodBusinessId;
            var createdBy = reservation.CreatedBy;
            var createdAt = reservation.CreatedAt;

            _mapper.Map(updateReservationCommand, reservation);
            Assert.Equal(reservation.ReservationName, updateReservationCommand.ReservationName);
            Assert.Equal(reservation.NumberOfDiners, updateReservationCommand.NumberOfDiners);
            Assert.Equal(reservation.ReservationDate, updateReservationCommand.ReservationDate);
            Assert.Equal(reservation.ReservationId, updateReservationCommand.CmdId);
            Assert.Equal(reservation.FoodBusinessId, foodBusinessId);
            Assert.Equal(reservation.CreatedBy, createdBy);
            Assert.Equal(reservation.CreatedAt, createdAt);
            Assert.Equal(reservation.LastModifiedBy, updateReservationCommand.LastModifiedBy);
            Assert.Equal(reservation.LastModifiedAt, updateReservationCommand.LastModifiedAt);
        }
    }
}