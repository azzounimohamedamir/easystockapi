using AutoMapper;
using SmartRestaurant.Application.Tests.Configuration;
using Xunit;
using SmartRestaurant.Application.Reservations.Commands;
using System;

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
        public void Map_FoodBusinessDto_To_FoodBusiness_Valide_Test()
        {
            var createReservationCommand = new CreateReservationCommand
            {
                ClientName = "Aissa",
                NumberOfDiners = 3,
                ReservationDate = DateTime.Now.AddDays(1),
                FoodBusinessId = Guid.NewGuid(),
                
            };

            var reservation = _mapper.Map<Domain.Entities.Reservation>(createReservationCommand);
            Assert.Equal(reservation.ClientName, createReservationCommand.ClientName);
            Assert.Equal(reservation.NumberOfDiners, createReservationCommand.NumberOfDiners);
            Assert.Equal(reservation.ReservationDate, createReservationCommand.ReservationDate);
            Assert.Equal(reservation.FoodBusinessId, createReservationCommand.FoodBusinessId);           
        }
    }
}