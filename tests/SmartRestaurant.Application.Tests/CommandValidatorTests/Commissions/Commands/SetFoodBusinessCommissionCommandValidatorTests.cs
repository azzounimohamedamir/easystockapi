using FluentValidation.TestHelper;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Commissions.Commands
{
    public class SetFoodBusinessCommissionCommandValidatorTests
    {
        private readonly SetFoodBusinessCommissionCommandValidator _validator;

        public SetFoodBusinessCommissionCommandValidatorTests()
        {
            _validator = new SetFoodBusinessCommissionCommandValidator();
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
        public void Given_FoodBusinessIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.FoodBusinessId, validEntry);
        }

        [Fact]
        public void Given_FoodBusinessIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.FoodBusinessId, _null);
        }

        [Fact]
        public void Given_ValueIsLessThanZero_WhenValidating_ShouldGetAnError()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.Value, -1);
        }

        [Fact]
        public void Given_ValueIsValid_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Value, 0);
        }

        [Fact]
        public void Given_TypePerPersonIsValid_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Type, CommissionType.PerPerson);
        }

        [Fact]
        public void Given_TypePerOrderIsValid_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.Type, CommissionType.PerOrder);
        }

        [Fact]
        public void Given_WhoPayFoodBusinessIsValid_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.WhoPay, WhoPayCommission.FoodBusiness);
        }

        [Fact]
        public void Given_WhoPayFoodBusinessCustomerIsValid_WhenValidating_ShouldBeValidated()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.WhoPay, WhoPayCommission.FoodBusinessCustomer);
        }

    }
}
