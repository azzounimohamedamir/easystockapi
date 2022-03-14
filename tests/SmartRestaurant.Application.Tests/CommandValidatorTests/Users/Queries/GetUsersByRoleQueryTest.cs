using FluentValidation.TestHelper;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Identity.Enums;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Users.Queries
{
    public class GetUsersByRoleQueryTest
    {
        private readonly GetUsersByRoleQueryValidator _validator;

        public GetUsersByRoleQueryTest()
        {
            _validator = new GetUsersByRoleQueryValidator();
        }
        
        [Fact]
        public void Given_RoleIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Role, _null);
        }
        [Fact]
        public void Given_RoleIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Role, empty);
        }
       
        [Fact]
        public void Given_RoleIsInvalid1_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid =  "FoodBusinessManagerr" ;
            _validator.ShouldHaveValidationErrorFor(x => x.Role, invalidGuid);
        }
        [Fact]
        public void Given_RoleIsInvalid2_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid =  Roles.SuperAdmin.ToString() ;
            _validator.ShouldHaveValidationErrorFor(x => x.Role, invalidGuid);
        }
        [Fact]
        public void Given_RoleIsValid1_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.SupportAgent.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid2_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.SalesMan.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid3_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Photograph.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid4_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.FoodBusinessAdministrator.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid5_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.FoodBusinessManager.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid6_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.FoodBusinessOwner.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid7_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Cashier.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid8_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Chef.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid9_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Waiter.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid10_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Diner.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid11_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Anounymous.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
        [Fact]
        public void Given_RoleIsValid12_WhenValidating_ShouldBeValidated()
        {
            var validEntry =  Roles.Organization.ToString() ;
            _validator.ShouldNotHaveValidationErrorFor(x => x.Role, validEntry);
        }
    }
}