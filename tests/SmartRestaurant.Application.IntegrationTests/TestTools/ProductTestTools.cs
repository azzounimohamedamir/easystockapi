using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Entities;

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
        public static async Task<CreateProductCommand> CreateProduct()
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
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

        public static async Task<Product> CreateProduct_2()
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
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

        public static async Task CreateProductsList(int numberOfProductsToCreate)
        {
            for (var i = 0; i < numberOfProductsToCreate; i++)
            {
                var createProductCommand = new CreateProductCommand
                {
                    Name = $"hamoud 2L {i}",
                    Description = $"description test {i}",
                    Price = 150 + i,
                    EnergeticValue = 200 + i
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