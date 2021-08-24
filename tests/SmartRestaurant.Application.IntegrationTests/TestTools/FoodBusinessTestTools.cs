using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class FoodBusinessTestTools
    {
        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }

        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness(string foodBusinessAdministratorId)
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = foodBusinessAdministratorId,
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }
    }
}