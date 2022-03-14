using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.Reservations.Commands;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class ReservationsTestTools
    {
        public static async Task Create_5_NonExpiredReservations(Domain.Entities.FoodBusiness fastFood,
            string reservationName, string client_UserId)
        {
            var dateTimeNow = DateTime.Now;
            for (var i = 1; i <= 5; i++)
            {
                var createReservationCommand = new CreateReservationCommand
                {
                    ReservationName = $"{reservationName}_NonExpiredReservations_{i}",
                    NumberOfDiners = 3 + i,
                    ReservationDate = dateTimeNow.AddHours(i),
                    FoodBusinessId = fastFood.FoodBusinessId,
                    CreatedBy = client_UserId
                };
                await SendAsync(createReservationCommand);
            }
        }

        public static async Task Create_3_ExpiredReservations(Domain.Entities.FoodBusiness fastFood,
            string reservationName, string client_UserId)
        {
            var dateTimeNow = DateTime.Now;

            for (var i = 1; i <= 3; i++)
            {
                var createReservationCommand = new CreateReservationCommand
                {
                    ReservationName = $"{reservationName}_ExpiredReservations_{i}",
                    NumberOfDiners = 1 + i,
                    ReservationDate = dateTimeNow.AddMilliseconds(i * 500),
                    FoodBusinessId = fastFood.FoodBusinessId,
                    CreatedBy = client_UserId
                };
                await SendAsync(createReservationCommand);
            }

            await Task.Delay(3500);
        }
    }
}