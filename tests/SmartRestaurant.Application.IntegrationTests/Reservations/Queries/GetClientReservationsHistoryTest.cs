using System;
using System.Threading;
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
    public class GetClientReservationsHistoryTest : TestBase
    {
        [Test]
        public async Task ShouldGetClientReservationsHistory()
        {
            var fastFood = await CreateFoodBusiness();

            string client_01_UserId = Guid.NewGuid().ToString();
            string client_02_UserId = Guid.NewGuid().ToString();

            await Create_5_NonExpiredReservations(fastFood,"Aissa", client_01_UserId);
            await Create_3_ExpiredReservations(fastFood, "Aissa", client_01_UserId);

            await Create_5_NonExpiredReservations(fastFood, "Bilel", client_02_UserId);
            await Create_3_ExpiredReservations(fastFood, "Bilel", client_02_UserId);
         
            var client_01_query_00 = new GetClientReservationsHistoryQuery
            {
                CreatedBy = client_01_UserId,
                Page = 1,
                PageSize = 5
            };
            var client_01_result_00 = await SendAsync(client_01_query_00);
            client_01_result_00.Data.Should().HaveCount(3);


            var client_01_query_01 = new GetClientReservationsHistoryQuery
            {
                CreatedBy = client_01_UserId,
                Page = 2,
                PageSize = 5
            };
            var client_01_result_01 = await SendAsync(client_01_query_01);
            client_01_result_01.Data.Should().HaveCount(0);


            var client_01_query_02 = new GetClientReservationsHistoryQuery
            {
                CreatedBy = client_01_UserId,
                Page = 1,
                PageSize = 2
            };
            var client_01_result_02 = await SendAsync(client_01_query_02);
            client_01_result_02.Data.Should().HaveCount(2);


            var client_01_query_03 = new GetClientReservationsHistoryQuery
            {
                CreatedBy = client_01_UserId,
                Page = 2,
                PageSize = 2
            };
            var client_01_result_03 = await SendAsync(client_01_query_03);
            client_01_result_03.Data.Should().HaveCount(1);


            var client_01_query_04 = new GetClientReservationsHistoryQuery
            {
                CreatedBy = client_01_UserId,
                Page = 3,
                PageSize = 2
            };
            var client_01_result_04 = await SendAsync(client_01_query_04);
            client_01_result_04.Data.Should().HaveCount(0);
        }

        private static async Task Create_5_NonExpiredReservations(Domain.Entities.FoodBusiness fastFood, string reservationName, string client_UserId)
        {
            DateTime dateTimeNow = DateTime.Now;
            for (int i = 1; i <= 5; i++)
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

        private static async Task Create_3_ExpiredReservations(Domain.Entities.FoodBusiness fastFood,string reservationName,  string client_UserId)
        {
            DateTime dateTimeNow = DateTime.Now;
           
            for (int i = 1; i <= 3; i++)
            {
                var createReservationCommand = new CreateReservationCommand
                {
                    ReservationName = $"{reservationName}_ExpiredReservations_{i}",
                    NumberOfDiners = 1 + i,
                    ReservationDate = dateTimeNow.AddMilliseconds(i*500),
                    FoodBusinessId = fastFood.FoodBusinessId,
                    CreatedBy = client_UserId
                };
                await SendAsync(createReservationCommand);               
            }
            await Task.Delay(3500);
        }

        private static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);
            return fastFood;
        }
    }
}