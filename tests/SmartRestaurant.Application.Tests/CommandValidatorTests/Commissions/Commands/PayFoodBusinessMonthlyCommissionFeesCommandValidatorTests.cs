using FluentValidation.TestHelper;
using SmartRestaurant.Application.CommissionsMonthlyFees.Commands;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Commissions.Commands
{
    public class PayFoodBusinessMonthlyCommissionFeesCommandValidatorTests
    {
        private readonly PayFoodBusinessMonthlyCommissionFeesCommandValidator _validator;

        public PayFoodBusinessMonthlyCommissionFeesCommandValidatorTests()
        {
            _validator = new PayFoodBusinessMonthlyCommissionFeesCommandValidator();
        }

        [Fact]
        public void Given_MonthlyCommissionIdIsEmpty_WhenValidating_ShouldGetAnError()
        {
            var empty = "";
            _validator.ShouldHaveValidationErrorFor(x => x.MonthlyCommissionId, empty);
        }

        [Fact]
        public void Given_MonthlyCommissionIdIsEmptyGuid_WhenValidating_ShouldGetAnError()
        {
            var emptyGuid = Guid.Empty.ToString();
            _validator.ShouldHaveValidationErrorFor(x => x.MonthlyCommissionId, emptyGuid);
        }

        [Fact]
        public void Given_MonthlyCommissionIdIsInvalidGuid_WhenValidating_ShouldGetAnError()
        {
            var invalidGuid = "3cbf3570-4444-4673-8746-2";
            _validator.ShouldHaveValidationErrorFor(x => x.MonthlyCommissionId, invalidGuid);
        }

        [Fact]
        public void Given_MonthlyCommissionIdIsValid_WhenValidating_ShouldBeValidated()
        {
            var validEntry = "acbf657b-3398-7a73-8746-77b7cf596315";
            _validator.ShouldNotHaveValidationErrorFor(x => x.MonthlyCommissionId, validEntry);
        }

        [Fact]
        public void Given_MonthlyCommissionIdIsNull_WhenValidating_ShouldGetAnError()
        {
            string _null = null;
            _validator.ShouldHaveValidationErrorFor(x => x.MonthlyCommissionId, _null);
        }      
    }
}
