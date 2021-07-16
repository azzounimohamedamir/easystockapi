using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Constants;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Reservations.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Reservations.Queries
{
    using static Testing;

    [TestFixture]
    public class GetReservationsListByReservationDateTimeIntervalTest : TestBase
    {
        [Test]
        public async Task ShouldGetReservationsList_ByReservationDateTimeInterval()
        {
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness();

            string client_01_UserId = Guid.NewGuid().ToString();
            string client_02_UserId = Guid.NewGuid().ToString();
            string FoodBusinessManager_UserId = Guid.NewGuid().ToString();

            await ReservationsTestTools.Create_5_NonExpiredReservations(fastFood, "Aissa", client_01_UserId);
            await ReservationsTestTools.Create_3_ExpiredReservations(fastFood, "Aissa", client_01_UserId);

            await ReservationsTestTools.Create_5_NonExpiredReservations(fastFood, "Bilel", client_02_UserId);
            await ReservationsTestTools.Create_3_ExpiredReservations(fastFood, "Bilel", client_02_UserId);

            var dateTimeNow = DateTime.Now;
            await Create_5_Reservations(fastFood, FoodBusinessManager_UserId, dateTimeNow);

            var query = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = Guid.NewGuid(),
                TimeIntervalStart = dateTimeNow,
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 0,
                PageSize = 5
            };
            var result = await SendAsync(query);
            result.Data.Should().HaveCount(0);


            var query_00 = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                TimeIntervalStart = dateTimeNow,
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 1,
                PageSize = 5
            };
            var result_00 = await SendAsync(query_00);
            result_00.Data.Should().HaveCount(5);


            var query_01 = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                TimeIntervalStart = dateTimeNow,
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 2,
                PageSize = 5
            };
            var result_01 = await SendAsync(query_01);
            result_01.Data.Should().HaveCount(0);


            var query_02 = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                TimeIntervalStart = dateTimeNow.AddHours(3),
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 1,
                PageSize = 2
            };
            var result_02 = await SendAsync(query_02);
            result_02.Data.Should().HaveCount(2);


            var query_03 = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                TimeIntervalStart = dateTimeNow.AddHours(3),
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 2,
                PageSize = 2
            };
            var result_03 = await SendAsync(query_03);
            result_03.Data.Should().HaveCount(1);


            var query_04 = new GetReservationsListByReservationDateTimeIntervalQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                TimeIntervalStart = dateTimeNow.AddHours(3),
                TimeIntervalEnd = dateTimeNow.AddHours(5),
                Page = 3,
                PageSize = 2
            };
            var result_04 = await SendAsync(query_04);
            result_04.Data.Should().HaveCount(0);
        }

        private static async Task Create_5_Reservations(Domain.Entities.FoodBusiness fastFood, string FoodBusinessManager_UserId, DateTime dateTimeNow)
        {
            for (var i = 1; i <= 5; i++)
            {
                var createReservationCommand = new CreateReservationCommand
                {
                    ReservationName = $"Aissa_{i}",
                    NumberOfDiners = 3 + i,
                    ReservationDate = dateTimeNow.AddHours(i),
                    FoodBusinessId = fastFood.FoodBusinessId,
                    CreatedBy = FoodBusinessManager_UserId               
                };
                await SendAsync(createReservationCommand);
            }
        }
    }
}