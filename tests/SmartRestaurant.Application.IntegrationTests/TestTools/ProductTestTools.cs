using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Products.Commands;

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
        public static async Task<CreateProductCommand> CreateProduct(Guid parentId, int parent)
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                SectionId = (parent == (int) ProductParent.Section) ? parentId.ToString() : null,
                SubSectionId = (parent == (int)ProductParent.SubSection) ? parentId.ToString() : null,
            };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createProductCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                await SendAsync(createProductCommand);
            };

            return createProductCommand;
        }
    }
}