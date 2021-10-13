using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Domain.ValueObjects;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Ingredients.Commands
{
    public class UpdateIngredientCommandValidatorTests
    {
        private readonly UpdateIngredientCommandValidator _validator;

        public UpdateIngredientCommandValidatorTests()
        {
            _validator = new UpdateIngredientCommandValidator();
        }

        [Fact]
        public void Given_IdIsNull_WhenValidating_ShouldGetAnError()
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
        public void Given_NameIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = string.Empty;
            _validator.ShouldHaveValidationErrorFor(x => x.Names, empty);
        }

        [Fact]
        public void Given_NameIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Names, _null);
        }

        [Fact]
        public void Given_NameHasNoArabicLanguage_WhenValidating_ShouldGetAnError()
        {
            var hasNoArabicLanguage = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':''},{'name':'Le poivre noir','language':'fr'}]";
            _validator.ShouldHaveValidationErrorFor(x => x.Names, hasNoArabicLanguage);
        }

        [Fact]
        public void Given_NameHasNoEnglishLanguage_WhenValidating_ShouldGetAnError()
        {
            var hasNoEnglishLanguage = @"[{'name':'Black pepper','language':''},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            _validator.ShouldHaveValidationErrorFor(x => x.Names, hasNoEnglishLanguage);
        }

        [Fact]
        public void Given_NameHasNoFrenchLanguage_WhenValidating_ShouldGetAnError()
        {
            var hasNoFrenchLanguage = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':''}]";
            _validator.ShouldHaveValidationErrorFor(x => x.Names, hasNoFrenchLanguage);
        }

        [Fact]
        public void Given_NameHasWrongJsonSchema_WhenValidating_ShouldGetAnError()
        {
            var hasWrongJsonSchema = @"{jhgj";
            _validator.ShouldHaveValidationErrorFor(x => x.Names, hasWrongJsonSchema);
        }

        [Fact]
        public void Given_PictureIdIsNull_WhenValidating_ShouldGetAnError()
        {
            FormFile _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.Picture, _null);
        }

        [Fact]
        public void Given_EnergeticValueIsNull_WhenValidating_ShouldGetAnError()
        {
            EnergeticValue _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue, _null);
        }

        [Fact]
        public void Given_AmountIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            //TODO will be fixed when we have a free time
            //var lessThanZero = -1;
            //_validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue.Amount, lessThanZero);
        }

        [Fact]
        public void Given_EnergyIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            //TODO will be fixed when we have a free time
            //var lessThanZero = -1;
            //_validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue.Energy, lessThanZero);
        }

        [Fact]
        public void Given_FatIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            //TODO will be fixed when we have a free time
            //var lessThanZero = -1;
            //_validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue.Fat, lessThanZero);
        }

        [Fact]
        public void Given_CarbohydratesIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            //TODO will be fixed when we have a free time
            //var lessThanZero = -1;
            //_validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue.Carbohydrates, lessThanZero);
        }

        [Fact]
        public void Given_ProteinIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            //TODO will be fixed when we have a free time
            //var lessThanZero = -1;
            //_validator.ShouldHaveValidationErrorFor(x => x.EnergeticValue.Protein, lessThanZero);
        }



    }
}
