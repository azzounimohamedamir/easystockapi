using AutoMapper;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class IllnessMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly CreateIllnessCommandValidator _createIllnessValidator ;
        private readonly IMapper _mapper;

        public IllnessMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
            _createIllnessValidator = new CreateIllnessCommandValidator();

        }
        [Fact]
        public void Map_CreateIllnessCommand_To_Illness_Valide_Test()
        {
            var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "Test"
            };
            var validationResult = _createIllnessValidator.Validate(createIllnessCommand);
            Assert.True(validationResult.IsValid);
            var illness = _mapper.Map<Domain.Entities.Illness>(createIllnessCommand);
            Assert.Equal(illness.Name, createIllnessCommand.Name);
            Assert.Equal(illness.IllnessId, createIllnessCommand.Id);
        }

      
    }
}
