
using SmartRestaurant.Application.Common.Tools;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Ingredients.Helpers
{
    public class IngredientNameValidator
    {
        [Fact]
        public void ValidateJsonSchemaForIngredientNames()
        {
            var json01 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var json02 = @"[{'name':'Black pepper','language':'en'}]";
            Assert.True(ValidatorHelper.ValidateJsonSchemaForIngredientNames(json01));
            Assert.True(ValidatorHelper.ValidateJsonSchemaForIngredientNames(json02));

            var unvalidJson00 = @"[]";
            var unvalidJson01 = @"[{'name':'Black pepper','lang':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson02 = @"[{'name':'Black pepper','language':'en'},{'namee':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson03 = @"[{'name':'Black pepper'},{'name':'الفلفل الاسود'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson04 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'language':'fr'}]";
            var unvalidJson05 = @"[{}]";
            var unvalidJson06 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{}]";
            var unvalidJson07 = @"{}";
            var unvalidJson08 = @"{jhgj";
            var unvalidJson09 = @"[{'name':'','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson10 = @"[{'name':'Black pepper','language':''},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson11 = @"[{'name':,'language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson12 = @"[{'name':'Black pepper','language':},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson13 = @"[{'name':'Black pepper','language':}{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var unvalidJson14 = @"{'name':'Black pepper','language':'en'}";
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(""));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(null));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson00));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson01));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson02));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson03));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson04));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson05));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson06));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson07));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson08));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson09));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson10));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson11));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson12));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson13));
            Assert.False(ValidatorHelper.ValidateJsonSchemaForIngredientNames(unvalidJson14));
        }

        [Fact]
        public void IngredientNamesHasArabicLanguage()
        {
            var json_ar_01 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var json_ar_02 = "[{'name':'Black pepper','language':\"en\"},{'name':'الفلفل الاسود','language':\"ar\"},{'name':'Le poivre noir','language':\"fr\"}]";
            Assert.True(ValidatorHelper.IngredientNamesHasArabicLanguage(json_ar_01));
            Assert.True(ValidatorHelper.IngredientNamesHasArabicLanguage(json_ar_02));

            var unvalid_json_ar_03 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':''},{'name':'Le poivre noir','language':'fr'}]";
            Assert.False(ValidatorHelper.IngredientNamesHasArabicLanguage(unvalid_json_ar_03));
        }

        [Fact]
        public void IngredientNamesHasEnglishLanguage()
        {
            var json_en_01 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var json_en_02 = "[{'name':'Black pepper','language':\"en\"},{'name':'الفلفل الاسود','language':\"ar\"},{'name':'Le poivre noir','language':\"fr\"}]";
            Assert.True(ValidatorHelper.IngredientNamesHasEnglishLanguage(json_en_01));
            Assert.True(ValidatorHelper.IngredientNamesHasEnglishLanguage(json_en_02));

            var unvalid_json_en_03 = @"[{'name':'Black pepper','language':''},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            Assert.False(ValidatorHelper.IngredientNamesHasEnglishLanguage(unvalid_json_en_03));
        }

        [Fact]
        public void IngredientNamesHasFrenchLanguage()
        {
            var json_fr_01 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]";
            var json_fr_02 = "[{'name':'Black pepper','language':\"en\"},{'name':'الفلفل الاسود','language':\"ar\"},{'name':'Le poivre noir','language':\"fr\"}]";
            Assert.True(ValidatorHelper.IngredientNamesHasFrenchLanguage(json_fr_01));
            Assert.True(ValidatorHelper.IngredientNamesHasFrenchLanguage(json_fr_02));

            var unvalid_json_fr_03 = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':''}]";
            Assert.False(ValidatorHelper.IngredientNamesHasFrenchLanguage(unvalid_json_fr_03));
        }
    }
}
