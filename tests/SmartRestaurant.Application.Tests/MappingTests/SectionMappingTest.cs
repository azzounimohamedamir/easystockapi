using System;
using AutoMapper;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class SectionMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;
 
        public SectionMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_AddProductToSectionCommand_To_SectionProduct_Valide_Test()
        {
            var addProductToSectionCommand = new AddProductToSectionCommand
            {
                SectionId = Guid.NewGuid().ToString(),
                ProductId = Guid.NewGuid().ToString()
            };

            var sectionProduct = _mapper.Map<SectionProduct>(addProductToSectionCommand);
            Assert.Equal(sectionProduct.SectionId, Guid.Parse(addProductToSectionCommand.SectionId));
            Assert.Equal(sectionProduct.ProductId, Guid.Parse(addProductToSectionCommand.ProductId));
        }

        [Fact]
        public void Map_AddDishToSectionCommand_To_SectionDish_Valide_Test()
        {
            var addDishToSectionCommand = new AddDishToSectionCommand
            {
                SectionId = Guid.NewGuid().ToString(),
                DishId = Guid.NewGuid().ToString()
            };

            var sectionDish = _mapper.Map<SectionDish>(addDishToSectionCommand);
            Assert.Equal(sectionDish.SectionId, Guid.Parse(addDishToSectionCommand.SectionId));
            Assert.Equal(sectionDish.DishId, Guid.Parse(addDishToSectionCommand.DishId));
        }      
    }
}