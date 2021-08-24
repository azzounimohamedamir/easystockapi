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
                FoodBusinessesIds = new List<string> {Guid.NewGuid().ToString()},
                Roles = new List<string> {Roles.FoodBusinessManager.ToString()}
            };

            var user = _mapper.Map<ApplicationUser>(InviteUserToJoinOrganizationCommand);

            Assert.Equal(user.Id, InviteUserToJoinOrganizationCommand.Id.ToString());
            Assert.Equal(user.Email, InviteUserToJoinOrganizationCommand.Email);
            Assert.Equal(user.UserName, InviteUserToJoinOrganizationCommand.Email);
        }

        [Fact]
        public void Map_UserAcceptsInvitationToJoinOrganizationCommand_To_ApplicationUser_Valide_Test()
        {
            var userAcceptsInvitationToJoinOrganizationCommand = new UserAcceptsInvitationToJoinOrganizationCommand
            {
                Id = Guid.NewGuid().ToString(),
                Email = "aissa@gmail.com",
                FullName = "aissa",
                Password = "12345678",
                PhoneNumber = "+213778865789",
                Token =
                    "CfDJ8BbYahOBwZlPqI/uQG3GnBrBsMyh3XmO1w4S0IberdjdDVsS9QXG1po9B/EJ7DKdW0C4U5/TpYOUmQiG77LmRicQXpJbc9953+pDDzzvYgYqXICUn8bild8ZhCWWVojXgaMCZl1FWOiRaqMgH/1lhwq0tZag93GQtITWCmVUNQW9h2/AhqMn4ArEp3RGov0Ja/th7ZAeIgNKgTUQHdn499VbFQJ+SXEGG1uYjkOPRx63"
            };

            var user = _mapper.Map<ApplicationUser>(userAcceptsInvitationToJoinOrganizationCommand);

            Assert.Null(user.Email);
            Assert.Null(user.UserName);
            Assert.Equal(user.Id, userAcceptsInvitationToJoinOrganizationCommand.Id);
            Assert.Equal(user.FullName, userAcceptsInvitationToJoinOrganizationCommand.FullName);
            Assert.Equal(user.PhoneNumber, userAcceptsInvitationToJoinOrganizationCommand.PhoneNumber);
        }
    }
}