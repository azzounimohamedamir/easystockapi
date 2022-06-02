using System;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
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
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "TestAR",
                    EN = "TestEN",
                    FR = "TestFR",
                    TR = "TestTR",
                    RU = "TestRU"
                },
                Price = 150,
                EnergeticValue = 200
            };


            var product = _mapper.Map<Product>(createProductCommand);
            Assert.Equal(product.ProductId, createProductCommand.Id);
            Assert.Equal(product.Name, createProductCommand.Name);

            Assert.Equal(product.Names.AR, createProductCommand.Names.AR);
            Assert.Equal(product.Names.EN, createProductCommand.Names.EN);
            Assert.Equal(product.Names.FR, createProductCommand.Names.FR);
            Assert.Equal(product.Names.TR, createProductCommand.Names.TR);
            Assert.Equal(product.Names.RU, createProductCommand.Names.RU);

            Assert.Equal(product.Description, createProductCommand.Description);
            Assert.Equal(product.Price, createProductCommand.Price);
            Assert.Equal(product.EnergeticValue, createProductCommand.EnergeticValue);
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
                Names = new Names()
                {
                    AR = "hamoud 2L AR",
                    EN = "hamoud 2L EN",
                    FR = "hamoud 2L FR",
                    TR = "hamoud 2L TR",
                    RU = "hamoud 2L RU"
                },
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                Picture = new byte[3] { 22, 23, 25 }
            };

            var updateProductCommand = new UpdateProductCommand
            {
                Id = productId.ToString(),
                Name = "IFRI 1L",
                Names = new NamesDto()
                {
                    AR = "IFRI 1L AR",
                    EN = "IFRI 1L EN",
                    FR = "IFRI 1L FR",
                    TR = "IFRI 1L TR",
                    RU = "IFRI 1L RU"
                },
                Description = "IFRI description test",
                Price = 80,
                EnergeticValue = 120,
                Picture = null

            };


            var updatedProduct = _mapper.Map(updateProductCommand, product);
            Assert.Equal(updatedProduct.ProductId, Guid.Parse(updateProductCommand.Id));
            Assert.Equal(updatedProduct.Name, updateProductCommand.Name);

            Assert.Equal(product.Names.AR, updatedProduct.Names.AR);
            Assert.Equal(product.Names.EN, updatedProduct.Names.EN);
            Assert.Equal(product.Names.FR, updatedProduct.Names.FR);
            Assert.Equal(product.Names.TR, updatedProduct.Names.TR);
            Assert.Equal(product.Names.RU, updatedProduct.Names.RU);

            Assert.Equal(updatedProduct.Description, updateProductCommand.Description);
            Assert.Equal(updatedProduct.Price, updateProductCommand.Price);
            Assert.Equal(updatedProduct.EnergeticValue, updateProductCommand.EnergeticValue);
            Assert.Equal(updatedProduct.Picture, new byte[3] { 22, 23, 25 });

        }

        [Fact]
        public void Map_Product_To_ProductDto_Valide_Test()
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "hamoud 2L",
                Names = new Names()
                {
                    AR = "hamoud 1L AR",
                    EN = "hamoud 1L EN",
                    FR = "hamoud 1L FR",
                    TR = "hamoud 1L TR",
                    RU = "hamoud 1L RU"
                },
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                Picture = new byte[3] { 22, 23, 25 }
            };
            
            var productDto = _mapper.Map<ProductDto>(product);
            Assert.Equal(productDto.ProductId, product.ProductId);
            Assert.Equal(productDto.Name, product.Name);

            Assert.Equal(product.Names.AR, productDto.Names.AR);
            Assert.Equal(product.Names.EN, productDto.Names.EN);
            Assert.Equal(product.Names.FR, productDto.Names.FR);
            Assert.Equal(product.Names.TR, productDto.Names.TR);
            Assert.Equal(product.Names.RU, productDto.Names.RU);

            Assert.Equal(productDto.Description, product.Description);
            Assert.Equal(productDto.Price, product.Price);
            Assert.Equal(productDto.EnergeticValue, product.EnergeticValue);
            Assert.Equal(productDto.Picture, Convert.ToBase64String(product.Picture));
        }
    }
}