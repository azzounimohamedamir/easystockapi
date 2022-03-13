using FluentValidation.TestHelper;
using SmartRestaurant.Application.Illness.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Illnesses.Queries
{
    public class GetDeshesIllnessQueryValidatorTest
    {
        private readonly GetDeshesIllnessQueryValidator _validator;

        public GetDeshesIllnessQueryValidatorTest()
        {
            _validator = new GetDeshesIllnessQueryValidator();
        }

        [Fact]
        public void Given_ListOfDishesIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = new List<string>();
            _validator.ShouldHaveValidationErrorFor(x => x.disheIds, empty);
        }
        [Fact]
        public void Given_ListOfIllnessIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = new List<string>();
            _validator.ShouldHaveValidationErrorFor(x => x.illnesIds, empty);
        }
        [Fact]
        public void Given_ListOfDishesIsNull_WhenValidating_ShouldGetAnError()
        {
            List<string> _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.disheIds, _null);
        }
        [Fact]
        public void Given_ListOfIllnessIsNull_WhenValidating_ShouldGetAnError()
        {
            List<string> _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.illnesIds, _null);
        }
    }
}
