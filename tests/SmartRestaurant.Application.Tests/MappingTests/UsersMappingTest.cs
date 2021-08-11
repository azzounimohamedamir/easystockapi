using System;
using AutoMapper;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Application.Common.Dtos;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class UsersMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;
        public UsersMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }


       

        [Fact]
        public void Map_ApplicationUser_To_foodBusinessEmployeesDto_Valide_Test()
        {
            var user = new ApplicationUser
            {
                 Id = Guid.NewGuid().ToString(),
                 Email = "aissa@gmail.com",
                 FullName = "aissa",
                 UserName = "aissa_user",
                 PhoneNumber = "07788991123",
                 IsActive = true
    };

            var foodBusinessEmployeesDto = _mapper.Map<FoodBusinessEmployees>(user);

            Assert.Equal(foodBusinessEmployeesDto.Id, user.Id);
            Assert.Equal(foodBusinessEmployeesDto.Email, user.Email);
            Assert.Equal(foodBusinessEmployeesDto.FullName, user.FullName);
            Assert.Equal(foodBusinessEmployeesDto.UserName, user.UserName);
            Assert.Equal(foodBusinessEmployeesDto.PhoneNumber, user.PhoneNumber);
            Assert.Equal(foodBusinessEmployeesDto.isActive, user.IsActive);
        }
    }
}