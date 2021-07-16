using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Constants;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Reservations.Queries;

namespace SmartRestaurant.Application.IntegrationTests.Reservations.Queries
{
    using static Testing;

    [TestFixture]
    public class GetClientNonExpiredReservationsTest : TestBase
    {
        [Test]
        public async Task ShouldGetClientNonExpiredReservations()
        {
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness();

            var client_01_UserId = Guid.NewGuid().ToString();
            var client_02_UserId = Guid.NewGuid().ToString();

            await ReservationsTestTools.Create_5_NonExpiredReservations(fastFood,"Aissa", client_01_UserId);
            await ReservationsTestTools.Create_3_ExpiredReservations(fastFood, "Aissa", client_01_UserId);

            await ReservationsTestTools.Create_5_NonExpiredReservations(fastFood, "Bilel", client_02_UserId);
            await ReservationsTestTools.Create_3_ExpiredReservations(fastFood, "Bilel", client_02_UserId);
         
            var client_01_query_00 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 1,
                PageSize = 5
            };
            var client_01_result_00 = await SendAsync(client_01_query_00);
            client_01_result_00.Data.Should().HaveCount(5);


            var client_01_query_01 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 2,
                PageSize = 5
            };
            var client_01_result_01 = await SendAsync(client_01_query_01);
            client_01_result_01.Data.Should().HaveCount(0);


            var client_01_query_02 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 1,
                PageSize = 2
            };
            var client_01_result_02 = await SendAsync(client_01_query_02);
            client_01_result_02.Data.Should().HaveCount(2);


            var client_01_query_03 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 2,
                PageSize = 2
            };
            var client_01_result_03 = await SendAsync(client_01_query_03);
            client_01_result_03.Data.Should().HaveCount(2);


            var client_01_query_04 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 3,
                PageSize = 2
            };
            var client_01_result_04 = await SendAsync(client_01_query_04);
            client_01_result_04.Data.Should().HaveCount(1);


            var client_01_query_05 = new GetClientNonExpiredReservationsQuery
            {
                UserId = client_01_UserId,
                Page = 4,
                PageSize = 2
            };
            var client_01_result_05 = await SendAsync(client_01_query_05);
            client_01_result_05.Data.Should().HaveCount(0);
        }
    }
}