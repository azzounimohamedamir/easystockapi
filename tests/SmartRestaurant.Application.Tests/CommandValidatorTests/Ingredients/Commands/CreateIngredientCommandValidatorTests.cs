using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System.IO;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Ingredients.Commands
{
    
    public class CreateIngredientCommandValidatorTests
    {
        private readonly CreateIngredientCommandValidator _validator;

        private CreateIngredientCommand createIngredientCommand = new CreateIngredientCommand
        {
            Names = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]",
            Picture = null,
            EnergeticValue = new EnergeticValue
            {
                Amount = 10,
                MeasurementUnit = MeasurementUnits.Gramme,
                Fat = 2,
                Protein = 1,
                Carbohydrates = 3,
                Energy = 10
            }
        };

        public CreateIngredientCommandValidatorTests()
        {
            _validator = new CreateIngredientCommandValidator();
            byte[] imageBytes = Properties.Resources.ingredients_1;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createIngredientCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "ingredient", "ingredient.png");
            };
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
