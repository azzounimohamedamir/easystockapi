using FluentValidation.TestHelper;
using SmartRestaurant.Application.CommissionsMonthlyFees.Queries;
using System;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Commissions.Queries
{
    public class GetMonthlyCommissionListBySmartRestaurantUserQueryValidatorTests
    {
        private readonly GetMonthlyCommissionListBySmartRestaurantUserQueryValidator _validator;

        public GetMonthlyCommissionListBySmartRestaurantUserQueryValidatorTests()
        {
            _validator = new GetMonthlyCommissionListBySmartRestaurantUserQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }
    }
}
