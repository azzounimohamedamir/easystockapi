﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.Hotels.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Queries
{
    using static Testing;


    public class GetAllHotelsByFoodBusinessManagerTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllHotelsAssignedToFoodBusinessManagerTests()
        {

            await RolesTestTools.CreateRoles();
            var AzHotelFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);

            var AzMostaghanem = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Mostaghanem");
            var AzAlger = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Alger");
            var AzOran = await HotelTestTools.CreateHotel(AzHotelFoodBusinessAdministrator.Id, "Az Oran");

            var IbisHotelFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var IbisAlger = await HotelTestTools.CreateHotel(IbisHotelFoodBusinessAdministrator.Id, "Ibis Hotel");
   


            var amirFoodBusinessManager = _authenticatedUserId;
            var assignAmirFoodBusinessManagerToAzAlger = new HotelUser
            {
                ApplicationUserId =amirFoodBusinessManager,
                HotelId = AzAlger.Id
            };
            await AddAsync(assignAmirFoodBusinessManagerToAzAlger);

            var assignAmirFoodBusinessManagerToAzOran = new HotelUser
            {
                ApplicationUserId = amirFoodBusinessManager,
                HotelId = AzOran.Id
            };
            await AddAsync(assignAmirFoodBusinessManagerToAzOran);

            var karimFoodBusinessManager = Guid.NewGuid().ToString();
            var assignKarimFoodBusinessManagerToAzMostaganem = new HotelUser
            {
                ApplicationUserId = karimFoodBusinessManager,
                HotelId = AzMostaghanem.Id
            };
            await AddAsync(assignKarimFoodBusinessManagerToAzMostaganem);


            var ahmedFoodBusinessManager = Guid.NewGuid().ToString();
            var assignAhmedFoodBusinessManagerToIbisAlger = new HotelUser
            {
                ApplicationUserId = ahmedFoodBusinessManager,
                HotelId = IbisAlger.Id
            };
            await AddAsync(assignAhmedFoodBusinessManagerToIbisAlger);


            var result = await SendAsync(new GetAllHotelsByFoodBusinessManagerQuery());

            result.Should().HaveCount(2);
            result.Should().NotBeNull();
        }
    }
}