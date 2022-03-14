using FluentValidation.TestHelper;
using SmartRestaurant.Application.Orders.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Orders.Commands
{
    public class CreateOrderCommandValidatorTests
    {
        private readonly CreateOrderCommandValidator _validator;

        public CreateOrderCommandValidatorTests()
        {
            _validator = new CreateOrderCommandValidator();
        }
   
        [Fact]
        public void Given_FoodBusinessIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, _null);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, empty);
        }

        [Fact]
        public void Given_FoodBusinessIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessId, validEntry);
        }

        [Fact]
        public void Given_FoodBusinessClientIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessClientId, empty);
        }

        [Fact]
        public void Given_FoodBusinessClientIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessClientId, emptyGuid);
        }

        [Fact]
        public void Given_FoodBusinessClientIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessClientId, invalidGuid);
        }

        [Fact]
        public void Given_FoodBusinessClientIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessClientId, validEntry);
        }

        [Fact]
        public void Given_FoodBusinessClientIdIsNull_WhenValidating_ShouldBeValidated()
        {
            string _null = null;
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessClientId, _null);
        }
    }
}
