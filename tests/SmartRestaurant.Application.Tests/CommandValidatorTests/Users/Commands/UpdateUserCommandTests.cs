using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Domain.Identity.Enums;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Users.Commands
{
    public class UpdateUserCommandTests
    {
        private readonly UpdateUserCommandValidator _validator;

        public UpdateUserCommandTests()
        {
            _validator = new UpdateUserCommandValidator();
        }

        [Fact]
        public void Given_ListOfFoodBusinessesIdsIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Id, _null);
        }

        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, empty);
        }

        [Fact]
        public void Given_IdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.Id, emptyGuid);
        }

        [Fact]
        public void Given_IdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.Id, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.Id, validEntry);
        }

        [Fact]
        public void Given_FullNameIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, _null);
        }

        [Fact]
        public void Given_FullNameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FullName, empty);
        }

        [Fact]
        public void Given_PhoneNumberIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, _null);
        }

        [Fact]
        public void Given_PhoneNumberIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, empty);
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
            var empty = new List<string>();
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
            var invalidGuid = new List<string> { Roles.SuperAdmin.ToString() };
            _validator.ShouldHaveValidationErrorFor(x => x.Roles, invalidGuid);
        }


        [Fact]
        public void Given_RoleIsValid1_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.SupportAgent.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid2_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.SalesMan.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid3_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Photograph.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid4_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.FoodBusinessAdministrator.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid5_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.FoodBusinessManager.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid6_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.FoodBusinessOwner.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid7_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Cashier.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid8_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Chef.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid9_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Waiter.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid10_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Diner.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid11_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Anounymous.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }

        [Fact]
        public void Given_RoleIsValid12_WhenValidating_ShouldBeValidated()
        {
            var validEntry = new List<string> { Roles.Organization.ToString() };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Roles, validEntry);
        }
    }
}