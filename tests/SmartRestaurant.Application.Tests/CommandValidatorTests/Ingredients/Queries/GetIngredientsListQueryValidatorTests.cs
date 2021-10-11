using FluentValidation.TestHelper;
using SmartRestaurant.Application.Ingredients.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Ingredients.Queries
{
    public class GetIngredientsListQueryValidatorTests
    {
        private readonly GetIngredientsListQueryValidator _validator;

        public GetIngredientsListQueryValidatorTests()
        {
            _validator = new GetIngredientsListQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }       
    }
}
