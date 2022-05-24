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
                Name = "Test",
                Names = new Common.Dtos.ValueObjects.NamesDto()
                {
                    AR = "TestAR",
                    EN = "TestEN",
                    FR = "TestFR",
                    TR = "TestTR",
                    RU = "TestRU"
                },
            };
            var validationResult = _createIllnessValidator.Validate(createIllnessCommand);
            Assert.True(validationResult.IsValid);
            var illness = _mapper.Map<Domain.Entities.Illness>(createIllnessCommand);
            Assert.Equal(illness.Name, createIllnessCommand.Name);
            Assert.Equal(illness.Names.AR, createIllnessCommand.Names.AR);
            Assert.Equal(illness.Names.EN, createIllnessCommand.Names.EN);
            Assert.Equal(illness.Names.FR, createIllnessCommand.Names.FR);
            Assert.Equal(illness.Names.TR, createIllnessCommand.Names.TR);
            Assert.Equal(illness.Names.RU, createIllnessCommand.Names.RU);
            Assert.Equal(illness.IllnessId, createIllnessCommand.Id);
        }

      
    }
}
