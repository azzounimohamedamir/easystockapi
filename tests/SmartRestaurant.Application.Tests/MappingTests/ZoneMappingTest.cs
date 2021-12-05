using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class ZoneMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public ZoneMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void Map_Zone_To_ZoneDto_Valide_Test()
        {
            var zone = new Zone
            {
                ZoneId = Guid.NewGuid(),
                ZoneTitle = "Class A",
                FoodBusinessId = Guid.NewGuid(),
                Tables = new List<Table>(),
            };
            zone.Tables.Add(
                new Table() 
                { 
                    TableId = Guid.NewGuid(), 
                    Capacity = 4, 
                    TableNumber = 1, 
                    ZoneId = zone.ZoneId, 
                    TableState = Domain.Enums.TableState.Available 
                });
            var zonetDto = _mapper.Map<ZoneWithTablesDto>(zone);
            Assert.Equal(zonetDto.ZoneId, zone.ZoneId);
            Assert.Equal(zonetDto.ZoneTitle, zone.ZoneTitle);
            Assert.Equal(zonetDto.FoodBusinessId, zone.FoodBusinessId);
            Assert.Equal(zonetDto.Tables[0].TableId, zone.Tables[0].TableId);
            Assert.Equal(zonetDto.Tables[0].Capacity, zone.Tables[0].Capacity);
            Assert.Equal(zonetDto.Tables[0].TableNumber, zone.Tables[0].TableNumber);
            Assert.Equal(zonetDto.Tables[0].ZoneId, zone.Tables[0].ZoneId);
            Assert.Equal(zonetDto.Tables[0].TableState, zone.Tables[0].TableState);
        }
    }
}