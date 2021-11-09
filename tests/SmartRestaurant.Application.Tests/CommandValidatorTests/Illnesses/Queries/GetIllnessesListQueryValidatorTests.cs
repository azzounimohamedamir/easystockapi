using FluentValidation.TestHelper;
using SmartRestaurant.Application.Illness.Queries;
using Xunit;

namespace SmartRestaurant.Application.Tests.CommandValidatorTests.Illnesses.Queries
{
    public class GetIllnessesListQueryValidatorTests
    {
        private readonly GetIllnessesListQueryValidator _validator;

        public GetIllnessesListQueryValidatorTests()
        {
            _validator = new GetIllnessesListQueryValidator();
        }

        [Fact]
        public void Given_PageSizeExceedMax_WhenValidating_ShouldGetAnError()
        {
            int exceedMax = 101;
            _validator.ShouldHaveValidationErrorFor(x => x.PageSize, exceedMax);
        }

    }
   
}
