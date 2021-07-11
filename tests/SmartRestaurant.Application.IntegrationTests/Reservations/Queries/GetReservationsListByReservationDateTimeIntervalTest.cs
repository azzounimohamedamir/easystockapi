using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Sections.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Sections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetReservationsListByReservationDateTimeIntervalTest : TestBase
    {
        [Test]
        public async Task ShouldGetReservationsList_ByReservationDateTimeInterval()
        {
            //Create a FoodBusiness
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.CmdId);

            //Create Reservations
            var dateTimeNow = DateTime.Now;
            for (var i = 1; i <= 5; i++)
            {
                var createReservationCommand = new CreateReservationCommand
                {
                    ReservationName = $"Aissa_{i}",
                    NumberOfDiners = 3 + i,
                    ReservationDate = dateTimeNow.AddHours(i),
                    FoodBusinessId = fastFood.FoodBusinessId,
                    CreatedBy = Guid.NewGuid().ToString()
                };
                await SendAsync(createReservationCommand);
            }

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
    }
}