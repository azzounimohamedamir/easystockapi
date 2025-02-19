﻿

using FluentValidation.TestHelper;
using SmartRestaurant.Application.Accounts.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Accounts.Commands
{
    public class AuthenticateViaSocialMediaCommandTests
    {
        private readonly AuthenticateViaSocialMediaCommandValidator _validator;

        public AuthenticateViaSocialMediaCommandTests()
        {
            _validator = new AuthenticateViaSocialMediaCommandValidator();
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
        public void Given_EmailExceedMax_WhenValidating_ShouldGetAnError()
        {
            string exceedMax = "testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt@test.com";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, exceedMax);
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
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Name, _null);
        }

        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Name, empty);
        }      
    }
}
