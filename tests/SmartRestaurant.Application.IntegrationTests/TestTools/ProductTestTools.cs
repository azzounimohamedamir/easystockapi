using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public enum ProductParent
    {
        Section = 0,
        SubSection = 1
    }
        public class ProductTestTools
    {
        public static async Task<CreateProductCommand> CreateProduct(Guid foodBusinessId)
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
                 FoodBusinessId = foodBusinessId.ToString(),
                Names = new NamesDto() { AR = "hamoud 2L AR", EN = "hamoud 2L EN", FR = "hamoud 2L FR", TR = "hamoud 2L TR", RU = "hamoud 2L RU" },
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createProductCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createProductCommand);
            };

            return createProductCommand;
        }

        public static async Task<Product> CreateProduct_2(Guid foodBusinessId)
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
                 FoodBusinessId = foodBusinessId.ToString(),
                Names=new NamesDto()
                {
                    AR= "hamoud 2L AR",
                    EN= "hamoud 2L EN",
                    FR= "hamoud 2L FR",
                    TR= "hamoud 2L TR",
                    RU= "hamoud 2L RU"
                },
                Description = "description test",
                Price = 150,
                EnergeticValue = 200
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createProductCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createProductCommand);
            };

            return await FindAsync<Product>(createProductCommand.Id);
        }

        public static async Task CreateProductsList(int numberOfProductsToCreate,Guid foodBusinessId)
        {
           

            for (var i = 0; i < numberOfProductsToCreate; i++)
            {
                var createProductCommand = new CreateProductCommand
                {
                    Name = $"hamoud 2L {i}",
                    Names = new NamesDto()
                    {
                        AR = $"hamoud 2L {i} AR",
                        EN = $"hamoud 2L {i} EN",
                        FR = $"hamoud 2L {i} FR",
                        TR = $"hamoud 2L {i} TR",
                        RU = $"hamoud 2L {i} RU"
                    },
                    Description = $"description test {i}",
                    Price = 150 + i,
                    EnergeticValue = 200 + i,
                    FoodBusinessId = foodBusinessId.ToString(),

                };

                byte[] imageBytes = Properties.Resources.food;
                using (var castStream = new MemoryStream(imageBytes))
                {
                    createProductCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                    await SendAsync(createProductCommand);
                };
            }           
        }
    }
}