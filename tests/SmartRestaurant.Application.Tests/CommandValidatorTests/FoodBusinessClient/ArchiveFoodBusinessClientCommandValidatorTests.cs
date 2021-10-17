using System;
using FluentValidation.TestHelper;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.FoodBusinessClient
{

    public class ArchiveFoodBusinessClientCommandValidatorTests
    {
        private readonly ArchiveFoodBusinessClientCommandValidator _validator;
        public ArchiveFoodBusinessClientCommandValidatorTests()
        {
            _validator = new ArchiveFoodBusinessClientCommandValidator();
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
        public void Given_ArchivedIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = true;
            _validator.ShouldNotHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Archived, validEntry);
        }

        [Fact]
        public void Given_UnarchivedIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = false;
            _validator.ShouldNotHaveValidationErrorFor(updateFoodBusinessClientCommand => updateFoodBusinessClientCommand.Archived, validEntry);
        }

    }
}
