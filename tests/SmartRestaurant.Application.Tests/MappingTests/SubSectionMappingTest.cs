using System;
using AutoMapper;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class SubSectionMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;
 
        public SubSectionMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_AddProductToSubSectionCommand_To_SubSectionProduct_Valide_Test()
        {
            var addProductToSubSectionCommand = new AddProductToSubSectionCommand
            {
                SubSectionId = Guid.NewGuid().ToString(),
                ProductId = Guid.NewGuid().ToString()
            };

            var subSectionProduct = _mapper.Map<SubSectionProduct>(addProductToSubSectionCommand);
            Assert.Equal(subSectionProduct.SubSectionId, Guid.Parse(addProductToSubSectionCommand.SubSectionId));
            Assert.Equal(subSectionProduct.ProductId, Guid.Parse(addProductToSubSectionCommand.ProductId));
        }

        [Fact]
        public void Map_AddDishToSubSectionCommand_To_SubSectionDish_Valide_Test()
        {
            var addDishToSubSectionCommand = new AddDishToSubSectionCommand
            {
                SubSectionId = Guid.NewGuid().ToString(),
                DishId = Guid.NewGuid().ToString()
            };

            var subSectionDish = _mapper.Map<SubSectionDish>(addDishToSubSectionCommand);
            Assert.Equal(subSectionDish.SubSectionId, Guid.Parse(addDishToSubSectionCommand.SubSectionId));
            Assert.Equal(subSectionDish.DishId, Guid.Parse(addDishToSubSectionCommand.DishId));
        }        
    }
}