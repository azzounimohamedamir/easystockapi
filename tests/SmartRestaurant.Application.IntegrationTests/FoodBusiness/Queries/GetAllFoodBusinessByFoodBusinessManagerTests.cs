using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;


    public class GetAllFoodBusinessByFoodBusinessManagerTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessAssignedToFoodBusinessManagerTests()
        {
            await RolesTestTools.CreateRoles();

            var tacosDzFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var tacosDz1 = await FoodBusinessTestTools.CreateFoodBusiness(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 01");           
            var tacosDz2 = await FoodBusinessTestTools.CreateFoodBusiness(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 02");           
            var tacosDz3 = await FoodBusinessTestTools.CreateFoodBusiness(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 03");
           
            var bigMamaFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var bigMama = await FoodBusinessTestTools.CreateFoodBusiness(bigMamaFoodBusinessAdministrator.Id, "bigMama Dz");
   


            var aissaFoodBusinessManager = _authenticatedUserId;
            var assignAissaFoodBusinessManagerToTacosDz1 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz1.FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz1);

            var assignAissaFoodBusinessManagerToTacosDz2 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz2.FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz2);

            var karimFoodBusinessManager = Guid.NewGuid().ToString();
            var assignKarimFoodBusinessManagerToTacosDz3 = new FoodBusinessUser
            {
                ApplicationUserId = karimFoodBusinessManager,
                FoodBusinessId = tacosDz3.FoodBusinessId
            };
            await AddAsync(assignKarimFoodBusinessManagerToTacosDz3);


            var ahmedFoodBusinessManager = Guid.NewGuid().ToString();
            var assignAhmedFoodBusinessManagerToBigMama = new FoodBusinessUser
            {
                ApplicationUserId = ahmedFoodBusinessManager,
                FoodBusinessId = bigMama.FoodBusinessId
            };
            await AddAsync(assignAhmedFoodBusinessManagerToBigMama);


            var result = await SendAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());

            result.Should().HaveCount(2);
        }
    }
}