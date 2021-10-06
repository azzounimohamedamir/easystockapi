using FluentValidation.TestHelper;
using SmartRestaurant.Application.Products.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Products.Commands
{
    public class GetProductListQueryValidatorTests
    {
        private readonly GetProductListQueryValidator _validator;

        public GetProductListQueryValidatorTests()
        {
            _validator = new GetProductListQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }       
    }
}
