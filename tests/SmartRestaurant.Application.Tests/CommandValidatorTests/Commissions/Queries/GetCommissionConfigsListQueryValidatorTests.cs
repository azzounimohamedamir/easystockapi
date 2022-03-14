using FluentValidation.TestHelper;
using SmartRestaurant.Application.commisiones.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Commissions.Queries
{
    public class GetCommissionConfigsListQueryValidatorTests
    {
        private readonly GetCommissionConfigsListQueryValidator _validator;

        public GetCommissionConfigsListQueryValidatorTests()
        {
            _validator = new GetCommissionConfigsListQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }        
    }
}
