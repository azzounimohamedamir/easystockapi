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

        public ReservationMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }


        [Fact]
        public void Map_CreateReservationCommand_To_Reservation_Valide_Test()
        {
            var createReservationCommand = new CreateReservationCommand
            {
                ClientName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = Guid.NewGuid()
            };

            var reservation = _mapper.Map<Reservation>(createReservationCommand);
            Assert.Equal(reservation.ClientName, createReservationCommand.ClientName);
            Assert.Equal(reservation.NumberOfDiners, createReservationCommand.NumberOfDiners);
            Assert.Equal(reservation.ReservationDate, createReservationCommand.ReservationDate);
            Assert.Equal(reservation.FoodBusinessId, createReservationCommand.FoodBusinessId);
        }

        [Fact]
        public void Map_UpdateReservationCommand_To_Reservation_Valide_Test()
        {
            var reservationId = Guid.NewGuid();
            var reservation = new Reservation
            {
                ClientName = "bilal",
                NumberOfDiners = 7,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = Guid.NewGuid(),
                ReservationId = reservationId
            };

            var updateReservationCommand = new UpdateReservationCommand
            {
                ClientName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(2),
                CmdId = reservationId
            };        

            var foodBusinessId = reservation.FoodBusinessId;

            _mapper.Map(updateReservationCommand, reservation);
            Assert.Equal(reservation.ClientName, updateReservationCommand.ClientName);
            Assert.Equal(reservation.NumberOfDiners, updateReservationCommand.NumberOfDiners);
            Assert.Equal(reservation.ReservationDate, updateReservationCommand.ReservationDate);
            Assert.Equal(reservation.ReservationId, updateReservationCommand.CmdId);
            Assert.Equal(reservation.FoodBusinessId, foodBusinessId);
        }
    }
}