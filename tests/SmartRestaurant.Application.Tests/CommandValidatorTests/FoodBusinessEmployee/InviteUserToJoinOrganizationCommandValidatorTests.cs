using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Domain.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessEmployee
{
    public class InviteUserToJoinOrganizationCommandValidatorTests
    {

        private readonly InviteUserToJoinOrganizationCommandValidator _validator;

        public InviteUserToJoinOrganizationCommandValidatorTests()
        {
            _validator = new InviteUserToJoinOrganizationCommandValidator();
        }

        [Fact]
        public void Given_EmailIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(x => x.Email, empty);
        }

        [Fact]
        public void Given_EmailIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Email, _null);
        }

        [Fact]
        public void Given_EmailIsInvalid_WhenValidating_ShouldGetAnError()
        {
            var invalidEmail = "test@test.";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, invalidEmail);
        }

        [Fact]
        public void Given_EmailIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "test@test.com";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, validEntry);
        }

        [Fact]
        public void Given_ListOfFoodBusinessesIdsIsNull_WhenValidating_ShouldGetAnError()
        {
            List<string> _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessesIds, _null);
        }

        [Fact]
        public void Given_ListOfFoodBusinessesIdsIsEmpty_WhenValidating_ShouldGetAnError()
        {
            List<string> empty = new List<string> {};
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessesIds, empty);
        }

        [Fact]
        public void Given_FoodBusinessIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = new List<string> { Guid.Empty.ToString() };
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessesIds, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = new List<string> { string.Empty };
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessesIds, empty);
        }

        [Fact]
        public void Given_FoodBusinessIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = new List<string> { "3cbf3570-4444-4673-8746-2" };
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessesIds, invalidGuid);
        } 

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { "acbf657b-3398-7a73-8746-77b7cf596315" };
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessesIds, validEntry);
        }

        [Fact]
        public void Given_ListOfRolesIsNull_WhenValidating_ShouldGetAnError()
        {
            List<string> _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, _null);
        }

        [Fact]
        public void Given_ListOfRolesIsEmpty_WhenValidating_ShouldGetAnError()
        {
            List<string> empty = new List<string> {};
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, empty);
        }

        [Fact]
        public void Given_RoleIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = new List<string> { string.Empty };
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, empty);
        }

        [Fact] 
        public void Given_RoleIsInvalid1_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = new List<string> { "FoodBusinessManagerr" };
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, invalidGuid);
        }

        [Fact]
        public void Given_RoleIsInvalid2_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = new List<string> { Roles.SupportAgent.ToString() };
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, invalidGuid);
        }

        [Fact]
        public void Given_RoleIsValid1_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.FoodBusinessManager.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid2_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Cashier.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid3_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Chef.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid4_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Waiter.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }
    }
}
