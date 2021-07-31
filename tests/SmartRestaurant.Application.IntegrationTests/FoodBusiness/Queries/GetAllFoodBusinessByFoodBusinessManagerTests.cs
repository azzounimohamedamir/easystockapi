using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;


    public class GetAllFoodBusinessByFoodBusinessManagerTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessAssignedToFoodBusinessManagerTests()
        {
            var tacosDzFoodBusinessAdministratorId = Guid.NewGuid().ToString();
            var tacosDz1 = new CreateFoodBusinessCommand
            {
                Name = "tacos Dz 01",
                FoodBusinessAdministratorId = tacosDzFoodBusinessAdministratorId,
                AverageRating = 12,
                HasCarParking = true
            };
            var tacosDz1FoodBusinessId = tacosDz1.Id;
            await SendAsync(tacosDz1);

            var tacosDz2 = new CreateFoodBusinessCommand
            {
                Name = "tacos Dz 02",
                FoodBusinessAdministratorId = tacosDzFoodBusinessAdministratorId,
                AverageRating = 10,
                HasCarParking = false
            };
            var tacosDz2FoodBusinessId = tacosDz2.Id;
            await SendAsync(tacosDz2);

            var tacosDz3 = new CreateFoodBusinessCommand
            {
                Name = "tacos Dz 03",
                FoodBusinessAdministratorId = tacosDzFoodBusinessAdministratorId,
                AverageRating = 10,
                HasCarParking = false
            };
            var tacosDz3FoodBusinessId = tacosDz3.Id;
            await SendAsync(tacosDz3);

            var BigMamaFoodBusinessAdministratorId = Guid.NewGuid().ToString();
            var bigMama = new CreateFoodBusinessCommand
            {
                Name = "bigMama Dz",
                FoodBusinessAdministratorId = BigMamaFoodBusinessAdministratorId,
                AverageRating = 10,
                HasCarParking = false
            };
            var bigMamaFoodBusinessId = bigMama.Id;
            await SendAsync(bigMama);


            var aissaFoodBusinessManager = _authenticatedUserId;
            var assignAissaFoodBusinessManagerToTacosDz1 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz1FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz1);

            var assignAissaFoodBusinessManagerToTacosDz2 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz2FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz2);

            var karimFoodBusinessManager = Guid.NewGuid().ToString();
            var assignKarimFoodBusinessManagerToTacosDz3 = new FoodBusinessUser
            {
                ApplicationUserId = karimFoodBusinessManager,
                FoodBusinessId = tacosDz3FoodBusinessId
            };
            await AddAsync(assignKarimFoodBusinessManagerToTacosDz3);


            var ahmedFoodBusinessManager = Guid.NewGuid().ToString();
            var assignAhmedFoodBusinessManagerToBigMama = new FoodBusinessUser
            {
                ApplicationUserId = ahmedFoodBusinessManager,
                FoodBusinessId = bigMamaFoodBusinessId
            };
            await AddAsync(assignAhmedFoodBusinessManagerToBigMama);


            var result = await SendAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());

            result.Should().HaveCount(2);
        }
    }
}