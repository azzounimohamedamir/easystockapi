using System;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
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

        [Fact]
        public void Map_UpdateProductCommand_To_Product_Valide_Test()
        {
            var productId = Guid.NewGuid();
            var product = new Product
            {
                ProductId = productId,
                Name = "hamoud 2L",
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                SectionId = Guid.NewGuid(),
                SubSectionId = Guid.NewGuid(),
                Picture = new byte[3] { 22, 23, 25 }
            };

            var updateProductCommand = new UpdateProductCommand
            {
                Id = productId.ToString(),
                Name = "IFRI 1L",
                Description = "IFRI description test",
                Price = 80,
                EnergeticValue = 120,
                Picture = null

            };


            var updatedProduct = _mapper.Map(updateProductCommand, product);
            Assert.Equal(updatedProduct.ProductId, Guid.Parse(updateProductCommand.Id));
            Assert.Equal(updatedProduct.Name, updateProductCommand.Name);
            Assert.Equal(updatedProduct.Description, updateProductCommand.Description);
            Assert.Equal(updatedProduct.Price, updateProductCommand.Price);
            Assert.Equal(updatedProduct.EnergeticValue, updateProductCommand.EnergeticValue);
            Assert.NotNull(updatedProduct.SectionId);
            Assert.NotNull(updatedProduct.SubSectionId);
            Assert.Equal(updatedProduct.Picture, new byte[3] { 22, 23, 25 });

        }

        [Fact]
        public void Map_Product_To_ProductDto_Valide_Test()
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "hamoud 2L",
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                SectionId = Guid.NewGuid(),
                SubSectionId = Guid.NewGuid(),
                Picture = new byte[3] { 22, 23, 25 }
            };
            
            var productDto = _mapper.Map<ProductDto>(product);
            Assert.Equal(productDto.ProductId, product.ProductId);
            Assert.Equal(productDto.Name, product.Name);
            Assert.Equal(productDto.Description, product.Description);
            Assert.Equal(productDto.Price, product.Price);
            Assert.Equal(productDto.EnergeticValue, product.EnergeticValue);
            Assert.Equal(productDto.SectionId, product.SectionId);
            Assert.Equal(productDto.SubSectionId, product.SubSectionId);
            Assert.Equal(productDto.Picture, Convert.ToBase64String(product.Picture));
        }
    }
}