using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessClient
{
    public class UpdateFoodBusinessClientCommandValidatorTests
    {
        private readonly UpdateFoodBusinessClientCommandValidator _validator;
        public UpdateFoodBusinessClientCommandValidatorTests()
        {
            _validator = new UpdateFoodBusinessClientCommandValidator();
        }

        [Fact]
        public void Given_EmptyGuid_WhenValidating_ShouldError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Id,
                emptyGuid);
        }
        [Fact]
        public void Given_IdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Id, empty);
        }

        [Fact]
        public void Given_IdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Id, invalidGuid);
        }

        [Fact]
        public void Given_NameIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Name, _null);
        }

        [Fact]
        public void Given_NameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Name, empty);
        }

        [Fact]
        public void Given_EmailIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Email, empty);
        }

        [Fact]
        public void Given_EmailIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Email, _null);
        }

        [Fact]
        public void Given_EmailIsInvalid_WhenValidating_ShouldGetAnError()
        {
            var invalidEmail = "test@test.";
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Email, invalidEmail);
        }

        [Fact]
        public void Given_EmailIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "test@test.com";
            _validator.ShouldNotHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Email, validEntry);
        }

        [Fact]
        public void Given_EmptyDescription_WhenValidating_ShouldError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Name,
                empty);
        }
             
      
        [Fact]
        public void Given_WebsiteIsInvalid_WhenValidating_ShouldGetAnError()
        {
            var invalidWebsite = "//g22rei.com";
            _validator.ShouldHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Website, invalidWebsite);
        }

        [Fact]
        public void Given_WebsiteIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "http://g22rei.com";
            _validator.ShouldNotHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Website, validEntry);
        }

    }
}
