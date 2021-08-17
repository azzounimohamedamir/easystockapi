using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class ApplicationUserMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public ApplicationUserMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_InviteUserToJoinOrganizationCommand_To_ApplicationUser_Valide_Test()
        {
            var InviteUserToJoinOrganizationCommand = new InviteUserToJoinOrganizationCommand
            {
                Email = "aissa@gmail.com",              
                FoodBusinessesIds = new List<string> { Guid.NewGuid().ToString() },
                Roles = new List<string> { Roles.FoodBusinessManager.ToString() }
        };

            var user = _mapper.Map<ApplicationUser>(InviteUserToJoinOrganizationCommand);

            Assert.Equal(user.Id, InviteUserToJoinOrganizationCommand.Id.ToString());
            Assert.Equal(user.Email, InviteUserToJoinOrganizationCommand.Email);
            Assert.Equal(user.UserName, InviteUserToJoinOrganizationCommand.Email);
  
        }
    }
}