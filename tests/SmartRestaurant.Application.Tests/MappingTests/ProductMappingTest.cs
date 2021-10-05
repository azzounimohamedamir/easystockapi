using System;
using AutoMapper;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class ProductMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public ProductMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }


        [Fact]
        public void Map_CreateProductCommand_To_Product_Valide_Test()
        {
            var createProductCommand = new CreateProductCommand
            {
                Name = "hamoud 2L",
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                SectionId = Guid.NewGuid().ToString(),
                SubSectionId = Guid.NewGuid().ToString()
            };


            var product = _mapper.Map<Product>(createProductCommand);
            Assert.Equal(product.ProductId, createProductCommand.Id);
            Assert.Equal(product.Name, createProductCommand.Name);
            Assert.Equal(product.Description, createProductCommand.Description);
            Assert.Equal(product.Price, createProductCommand.Price);
            Assert.Equal(product.EnergeticValue, createProductCommand.EnergeticValue);
            Assert.Equal(product.SectionId, Guid.Parse(createProductCommand.SectionId));
            Assert.Equal(product.SubSectionId, Guid.Parse(createProductCommand.SubSectionId));
            Assert.Null(product.Picture);

        }
    }
}